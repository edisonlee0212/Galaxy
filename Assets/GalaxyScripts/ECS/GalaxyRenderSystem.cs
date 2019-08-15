using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Galaxy
{
    public struct StarRenderInfo
    {
        public float4x4 LocalToWorld;
        public float4 EmissionColor;
    }

    public static class GalaxyRenderSystemConstants
    {
        #region Stride Sizes
        // Compute buffer stride sizes
        public static readonly int STRIDE_SIZE_MATRIX4X4 = 64;
        public static readonly int STRIDE_SIZE_BOOL = 4;
        public static readonly int STRIDE_SIZE_INT = 4;
        public static readonly int STRIDE_SIZE_FLOAT = 4;
        public static readonly int STRIDE_SIZE_FLOAT4 = 16;
        #endregion Stride Sizes

        public static readonly string[] VISIBILITY_COMPUTE_KERNELS = new string[] {
            "OBBFrustumCullingKernel",
            "SphereFrustumCullingKernel"};
        public static readonly string OBB_FRUSTUM_CULLING_KERNEL_RESOURCE_PATH = "ComputeShaders/OBBFrustumCullingKernel";
        public static readonly string SPHERE_FRUSTUM_CULLING_KERNEL_RESOURCE_PATH = "ComputeShaders/SphereFrustumCullingKernel";
        public static readonly float VISIBILITY_SHADER_THREAD_COUNT = 1024;
        public static readonly int TRANSFORMATION_MATRIX_APPEND_BUFFERS = Shader.PropertyToID("gpuiTransformationMatrix");
        public static readonly int INSTANCE_DATA_BUFFER = Shader.PropertyToID("gpuiInstanceData");
        public static readonly int BUFFER_PARAMETER_BUFFER_SIZE = Shader.PropertyToID("bufferSize");
        public static class VisibilityKernelPopertiesForOBBFrustumCullingConstants
        {
            public static readonly int RENDERER_TRANSFORM_OFFSET = Shader.PropertyToID("gpuiTransformOffset");
            public static readonly int BUFFER_PARAMETER_MVP_MATRIX = Shader.PropertyToID("mvpMartix");
            public static readonly int BUFFER_PARAMETER_BOUNDS_CENTER = Shader.PropertyToID("boundsCenter");
            public static readonly int BUFFER_PARAMETER_BOUNDS_EXTENTS = Shader.PropertyToID("boundsExtents");
            public static readonly int BUFFER_PARAMETER_FRUSTUM_OFFSET = Shader.PropertyToID("frustumOffset");
            public static readonly int BUFFER_PARAMETER_MAX_VIEW_DISTANCE = Shader.PropertyToID("maxDistance");
            public static readonly int BUFFER_PARAMETER_CAMERA_POSITION = Shader.PropertyToID("camPos");
            public static readonly int BUFFER_PARAMETER_HALF_ANGLE = Shader.PropertyToID("halfAngle");
            public static readonly int BUFFER_PARAMETER_MIN_CULLING_DISTANCE = Shader.PropertyToID("minCullingDistance");
        }
        public static class VisibilityKernelPopertiesForSphereFrustumCullingConstants
        {
            public static readonly int CAMERA_FRUSTUM_PLANES = Shader.PropertyToID("frustumPlanes");
        }
    }

    [UpdateInGroup(typeof(PresentationSystemGroup))]
    public class GalaxyRenderSystem : JobComponentSystem
    {
        #region Attributes
        private static EndSimulationEntityCommandBufferSystem m_CommandBufferSystem;
        private static EntityQuery m_InstanceQuery;
        private static NativeArray<CustomLocalToWorld> m_StarLocalToWorlds;
        private static NativeList<CustomLocalToWorld> m_StarConnectionsLocalToWorlds;
        private static NativeArray<DisplayColor> m_CustomColors;
        private static NativeList<DisplayColor> m_StarConnectionsColors;
        private static NativeList<StarConnection> m_StarConnections;
        private static Matrix4x4[] m_Matrices;
        private static Vector4[] m_Colors;
        private static float4x4[] m_IndirectMatrices;
        private static float4[] m_IndirectColors;
        private static StarRenderInfo[] m_StarRenderInfos;
        private static MaterialPropertyBlock m_MaterialPropertyBlock;
        private static ComputeBuffer m_StarRenderInfoBuffer;
        private static ComputeBuffer m_ArgsBuffer;
        private static uint[] args;
        private static Camera m_Camera;


        private static ComputeBuffer m_TransformationMatrixAppendBuffer;
        private static ComputeShader m_OBBFrustumCullingComputeShader;
        private static ComputeShader m_SphereFrustumCullingComputeShader;
        private static float[] m_MvpMatrixFloats;
        private static ComputeBuffer m_LocalToWorldBuffer;
        private static ComputeBuffer m_EmissionColorBuffer;
        private static ComputeBuffer m_CameraPlanesBuffer;
        #endregion

        #region Public
        private static int m_StarAmount;
        private static bool m_EnableInstancedIndirect;
        private static bool m_EnableGPUFrustumCulling;
        private static UnityEngine.Mesh m_StarMesh;
        private static UnityEngine.Material m_StarMaterial;
        private static UnityEngine.Material m_StarIndirectMaterial;
        private static UnityEngine.Material m_StarIndirectGPUCullingMaterial;

        private static UnityEngine.Mesh m_StarConnectionMesh;
        private static UnityEngine.Material m_StarConnectionMaterial;
        private static Light m_Light;
        private static PlanetOrbits m_PlanetOrbits;
        private static bool m_DrawConnections;
        private static bool m_SequenceConnect;
        public static NativeList<StarRenderInfo> m_StarInfoList;
        public static UnityEngine.Mesh StarMesh { get => m_StarMesh; set => m_StarMesh = value; }
        public static UnityEngine.Material StarMaterial { get => m_StarMaterial; set => m_StarMaterial = value; }
        public static bool EnableInstancedIndirect { get => m_EnableInstancedIndirect; set => m_EnableInstancedIndirect = value; }
        public static Light Light { get => m_Light; set => m_Light = value; }
        public static PlanetOrbits PlanetOrbits { get => m_PlanetOrbits; set => m_PlanetOrbits = value; }
        public static int StarAmount { get => m_StarAmount; set => m_StarAmount = value; }
        public static UnityEngine.Material StarIndirectMaterial { get => m_StarIndirectMaterial; set => m_StarIndirectMaterial = value; }
        public static bool DrawConnections { get => m_DrawConnections; set => m_DrawConnections = value; }
        public static Mesh StarConnectionMesh { get => m_StarConnectionMesh; set => m_StarConnectionMesh = value; }
        public static UnityEngine.Material StarConnectionMaterial { get => m_StarConnectionMaterial; set => m_StarConnectionMaterial = value; }
        public static bool SequenceConnect { get => m_SequenceConnect; set => m_SequenceConnect = value; }
        public static bool EnableGPUFrustumCulling { get => m_EnableGPUFrustumCulling; set => m_EnableGPUFrustumCulling = value; }
        public static Material StarIndirectGPUCullingMaterial { get => m_StarIndirectGPUCullingMaterial; set => m_StarIndirectGPUCullingMaterial = value; }
        #endregion

        #region Managers
        protected override void OnCreateManager()
        {
            Enabled = false;
        }

        public void Init()
        {
            ShutDown();

            m_Camera = Camera.main;

            m_InstanceQuery = EntityManager.CreateEntityQuery(typeof(CustomLocalToWorld), typeof(StarProperties), typeof(DisplayColor));
            #region Star Connections
            m_StarConnections = new NativeList<StarConnection>(Allocator.Persistent);
            m_StarConnectionsLocalToWorlds = new NativeList<CustomLocalToWorld>(Allocator.Persistent);
            m_StarConnectionsColors = new NativeList<DisplayColor>(Allocator.Persistent);
            #endregion

            #region DrawMeshInstancedIndirect;
            args = new uint[5] { m_StarMesh.GetIndexCount(0), (uint)m_StarAmount, 0, 0, 0 };
            m_ArgsBuffer = new ComputeBuffer(1, args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
            m_ArgsBuffer.SetData(args);
            if (m_EnableGPUFrustumCulling)
            {
                m_IndirectMatrices = new float4x4[m_StarAmount];
                m_IndirectColors = new float4[m_StarAmount];
                m_LocalToWorldBuffer = new ComputeBuffer(m_StarAmount, GalaxyRenderSystemConstants.STRIDE_SIZE_MATRIX4X4);
                m_EmissionColorBuffer = new ComputeBuffer(m_StarAmount, GalaxyRenderSystemConstants.STRIDE_SIZE_FLOAT4);
                m_OBBFrustumCullingComputeShader = Resources.Load<ComputeShader>(GalaxyRenderSystemConstants.OBB_FRUSTUM_CULLING_KERNEL_RESOURCE_PATH);
                m_SphereFrustumCullingComputeShader = Resources.Load<ComputeShader>(GalaxyRenderSystemConstants.SPHERE_FRUSTUM_CULLING_KERNEL_RESOURCE_PATH);
                m_MvpMatrixFloats = new float[16];
                m_TransformationMatrixAppendBuffer = new ComputeBuffer(m_StarAmount, GalaxyRenderSystemConstants.STRIDE_SIZE_INT, ComputeBufferType.Append);
                m_TransformationMatrixAppendBuffer.SetCounterValue(0);
                m_CameraPlanesBuffer = new ComputeBuffer(6, GalaxyRenderSystemConstants.STRIDE_SIZE_FLOAT4);
            }
            else
            {
                m_StarRenderInfoBuffer = new ComputeBuffer(m_StarAmount, 80);
                m_StarRenderInfos = new StarRenderInfo[m_StarAmount];
                m_StarInfoList = new NativeList<StarRenderInfo>(Allocator.Persistent);
            }
            #endregion

            #region DrawMeshInstanced;
            m_Matrices = new Matrix4x4[1023];
            m_Colors = new Vector4[1023];
            m_MaterialPropertyBlock = new MaterialPropertyBlock();
            m_CommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            #endregion

            //Start
            if (m_SequenceConnect) for (int i = 0; i < m_StarAmount - 1; i++)
                {
                    AddStarConnection(new StarConnection
                    {
                        FromIndex = i,
                        ToIndex = i + 1
                    });
                }
            m_DrawConnections = true;
            Enabled = true;
        }

        public void ShutDown()
        {
            Enabled = false;
            if (m_InstanceQuery != null) m_InstanceQuery.Dispose();
            if (m_StarLocalToWorlds.IsCreated) m_StarLocalToWorlds.Dispose();
            if (m_CustomColors.IsCreated) m_CustomColors.Dispose();
            if (m_StarRenderInfoBuffer != null) m_StarRenderInfoBuffer.Release();
            if (m_StarInfoList.IsCreated) m_StarInfoList.Dispose();
            if (m_ArgsBuffer != null) m_ArgsBuffer.Release();
            if (m_StarConnections.IsCreated) m_StarConnections.Dispose();
            if (m_StarConnectionsLocalToWorlds.IsCreated) m_StarConnectionsLocalToWorlds.Dispose();
            if (m_StarConnectionsColors.IsCreated) m_StarConnectionsColors.Dispose();
            if (m_TransformationMatrixAppendBuffer != null) m_TransformationMatrixAppendBuffer.Dispose();
            if (m_LocalToWorldBuffer != null) m_LocalToWorldBuffer.Release();
            if (m_EmissionColorBuffer != null) m_EmissionColorBuffer.Release();
            if (m_CameraPlanesBuffer != null) m_CameraPlanesBuffer.Dispose();
        }

        protected override void OnDestroyManager()
        {
            ShutDown();
        }
        #endregion

        #region Methods

        #region GPU Culling

        public static void Matrix4x4ToFloatArray(Matrix4x4 matrix4x4, ref float[] floatArray)
        {
            floatArray[0] = matrix4x4[0, 0];
            floatArray[1] = matrix4x4[1, 0];
            floatArray[2] = matrix4x4[2, 0];
            floatArray[3] = matrix4x4[3, 0];
            floatArray[4] = matrix4x4[0, 1];
            floatArray[5] = matrix4x4[1, 1];
            floatArray[6] = matrix4x4[2, 1];
            floatArray[7] = matrix4x4[3, 1];
            floatArray[8] = matrix4x4[0, 2];
            floatArray[9] = matrix4x4[1, 2];
            floatArray[10] = matrix4x4[2, 2];
            floatArray[11] = matrix4x4[3, 2];
            floatArray[12] = matrix4x4[0, 3];
            floatArray[13] = matrix4x4[1, 3];
            floatArray[14] = matrix4x4[2, 3];
            floatArray[15] = matrix4x4[3, 3];
        }

        public static void DispatchOBBFrustumCalculation(Mesh mesh, ComputeBuffer matrixBuffer, ComputeBuffer resultBuffer, int totalInstanceAmount)
        {
            Matrix4x4ToFloatArray(m_Camera.projectionMatrix * m_Camera.worldToCameraMatrix, ref m_MvpMatrixFloats);
            m_OBBFrustumCullingComputeShader.SetBuffer(0, GalaxyRenderSystemConstants.INSTANCE_DATA_BUFFER, 
                matrixBuffer);
            m_OBBFrustumCullingComputeShader.SetBuffer(0, GalaxyRenderSystemConstants.TRANSFORMATION_MATRIX_APPEND_BUFFERS, 
                resultBuffer);
            m_OBBFrustumCullingComputeShader.SetFloats(GalaxyRenderSystemConstants.VisibilityKernelPopertiesForOBBFrustumCullingConstants.BUFFER_PARAMETER_MVP_MATRIX,
                m_MvpMatrixFloats);
            m_OBBFrustumCullingComputeShader.SetVector(GalaxyRenderSystemConstants.VisibilityKernelPopertiesForOBBFrustumCullingConstants.BUFFER_PARAMETER_BOUNDS_CENTER,
                mesh.bounds.center);
            m_OBBFrustumCullingComputeShader.SetVector(GalaxyRenderSystemConstants.VisibilityKernelPopertiesForOBBFrustumCullingConstants.BUFFER_PARAMETER_BOUNDS_EXTENTS,
                mesh.bounds.extents);
            m_OBBFrustumCullingComputeShader.SetFloat(GalaxyRenderSystemConstants.VisibilityKernelPopertiesForOBBFrustumCullingConstants.BUFFER_PARAMETER_MAX_VIEW_DISTANCE,
                m_Camera.farClipPlane);
            m_OBBFrustumCullingComputeShader.SetVector(GalaxyRenderSystemConstants.VisibilityKernelPopertiesForOBBFrustumCullingConstants.BUFFER_PARAMETER_CAMERA_POSITION,
                m_Camera.transform.position);
            m_OBBFrustumCullingComputeShader.SetFloat(GalaxyRenderSystemConstants.VisibilityKernelPopertiesForOBBFrustumCullingConstants.BUFFER_PARAMETER_FRUSTUM_OFFSET,
                0.2f);
            m_OBBFrustumCullingComputeShader.SetFloat(GalaxyRenderSystemConstants.VisibilityKernelPopertiesForOBBFrustumCullingConstants.BUFFER_PARAMETER_MIN_CULLING_DISTANCE,
                0);
            m_OBBFrustumCullingComputeShader.SetInt(GalaxyRenderSystemConstants.BUFFER_PARAMETER_BUFFER_SIZE,
                totalInstanceAmount);
            m_OBBFrustumCullingComputeShader.SetFloat(GalaxyRenderSystemConstants.VisibilityKernelPopertiesForOBBFrustumCullingConstants.BUFFER_PARAMETER_HALF_ANGLE, 
                Mathf.Tan(Mathf.Deg2Rad * m_Camera.fieldOfView * 0.25f));
            // Dispatch the compute shader
            m_OBBFrustumCullingComputeShader.Dispatch(0,Mathf.CeilToInt(totalInstanceAmount / GalaxyRenderSystemConstants.VISIBILITY_SHADER_THREAD_COUNT), 1, 1);

            // Copy (overwrite) the modified instance count of the append buffer to each index of the indirect renderer buffer (argsBuffer)
            // that represents a submesh's instance count. The offset is calculated in parallel to the Graphics.DrawMeshInstancedIndirect call,
            // which expects args[1] to be the instance count for the first LOD's first renderer. Every 5 index offset of args represents the 
            // next submesh in the renderer, followed by the next renderer and it's submeshes. After all submeshes of all renderers for the 
            // first LOD, the other LODs follow in the same manner.
            // For reference, see: https://docs.unity3d.com/ScriptReference/ComputeBuffer.CopyCount.html
            ComputeBuffer.CopyCount(resultBuffer, m_ArgsBuffer, 1);
        }

        public static void DispatchSphereFrustumCalculation(Mesh mesh, ComputeBuffer matrixBuffer, ComputeBuffer resultBuffer, int totalInstanceAmount)
        {
            var planes = GeometryUtility.CalculateFrustumPlanes(m_Camera);
            float4[] frustumPlanes = new float4[6];
            for (int i = 0; i < 6; i++)
            {
                frustumPlanes[i].x = planes[i].normal.x;
                frustumPlanes[i].y = planes[i].normal.y;
                frustumPlanes[i].z = planes[i].normal.z;
                frustumPlanes[i].w = planes[i].distance;
            }
            m_SphereFrustumCullingComputeShader.SetBuffer(0, GalaxyRenderSystemConstants.INSTANCE_DATA_BUFFER,
                matrixBuffer);
            m_SphereFrustumCullingComputeShader.SetBuffer(0, GalaxyRenderSystemConstants.TRANSFORMATION_MATRIX_APPEND_BUFFERS,
                resultBuffer);
            m_CameraPlanesBuffer.SetData(frustumPlanes);
            m_SphereFrustumCullingComputeShader.SetBuffer(0, GalaxyRenderSystemConstants.VisibilityKernelPopertiesForSphereFrustumCullingConstants.CAMERA_FRUSTUM_PLANES,
                m_CameraPlanesBuffer);
            m_SphereFrustumCullingComputeShader.SetInt(GalaxyRenderSystemConstants.BUFFER_PARAMETER_BUFFER_SIZE,
                totalInstanceAmount);
            // Dispatch the compute shader
            m_SphereFrustumCullingComputeShader.Dispatch(0, Mathf.CeilToInt(totalInstanceAmount / GalaxyRenderSystemConstants.VISIBILITY_SHADER_THREAD_COUNT), 1, 1);
            ComputeBuffer.CopyCount(resultBuffer, m_ArgsBuffer, 1);
        }


        #endregion

        public static void AddStarConnection(StarConnection starConnection)
        {
            //Validity check.
            if (starConnection.FromIndex == starConnection.ToIndex || starConnection.FromIndex < 0 || starConnection.ToIndex < 0 || starConnection.FromIndex >= m_StarAmount || starConnection.ToIndex >= m_StarAmount) return;
            Debug.Log("Adding connection from " + starConnection.FromIndex + " to " + starConnection.ToIndex);
            m_StarConnections.Add(starConnection);
            m_StarConnectionsLocalToWorlds.Add(default);
            m_StarConnectionsColors.Add(default);
        }

        public static void ClearConnections()
        {
            m_StarConnections.Clear();
            m_StarConnectionsLocalToWorlds.Clear();
            m_StarConnectionsColors.Clear();
        }

        #region Memcpy
        public static unsafe void ToArray(NativeSlice<CustomLocalToWorld> transforms, int count, Matrix4x4[] outMatrices, int offset)
        {
            fixed (Matrix4x4* resultMatrices = outMatrices)
            {
                CustomLocalToWorld* sourceMatrices = (CustomLocalToWorld*)transforms.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<Matrix4x4>() * count);
            }
        }


        public static unsafe void ToArray(NativeSlice<DisplayColor> colors, int count, Vector4[] outMatrices, int offset)
        {
            fixed (Vector4* resultMatrices = outMatrices)
            {
                DisplayColor* sourceMatrices = (DisplayColor*)colors.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<Vector4>() * count);
            }
        }

        public static unsafe void ToArray(NativeArray<DisplayColor> colors, int count, float4[] outMatrices, int offset)
        {
            fixed (float4* resultMatrices = outMatrices)
            {
                DisplayColor* sourceMatrices = (DisplayColor*)colors.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<float4>() * count);
            }
        }

        private static unsafe void ToArray(NativeArray<CustomLocalToWorld> transforms, int count, float4x4[] outMatrices, int offset)
        {
            fixed (float4x4* resultMatrices = outMatrices)
            {
                CustomLocalToWorld* sourceMatrices = (CustomLocalToWorld*)transforms.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<float4x4>() * count);
            }
        }

        private static unsafe void ToArray(NativeArray<StarRenderInfo> transforms, int count, StarRenderInfo[] outMatrices, int offset)
        {
            fixed (StarRenderInfo* resultMatrices = outMatrices)
            {
                StarRenderInfo* sourceMatrices = (StarRenderInfo*)transforms.GetUnsafeReadOnlyPtr();
                UnsafeUtility.MemCpy(resultMatrices + offset, sourceMatrices, UnsafeUtility.SizeOf<StarRenderInfo>() * count);
            }
        }
        #endregion

        #endregion

        #region Jobs
        [BurstCompile]
        public struct StarConnectionsGenerator : IJobParallelFor
        {
            [ReadOnly] public NativeArray<CustomLocalToWorld> customLocalToWorlds;
            [ReadOnly] public NativeArray<StarConnection> starConnections;
            [ReadOnly] public NativeArray<DisplayColor> customColors;
            [ReadOnly] public Vector3 cameraPosition;
            [WriteOnly] public NativeArray<CustomLocalToWorld> starConnectionsLocalToWorlds;
            [WriteOnly] public NativeArray<DisplayColor> starConnectionsColors;
            [ReadOnly] public float widthFactor;
            public void Execute(int index)
            {
                StarConnection connection = starConnections[index];
                float3 from = customLocalToWorlds[connection.FromIndex].Position;
                float3 to = customLocalToWorlds[connection.ToIndex].Position;
                float3 diff = to - from;
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, diff);
                CustomLocalToWorld customLocalToWorld = new CustomLocalToWorld
                {
                    Value = math.mul(new float4x4(rotation,
                    (from + to) / 2),
                    float4x4.Scale(new float3(widthFactor, Vector3.Distance(from, to), widthFactor)))
                };
                starConnectionsLocalToWorlds[index] = customLocalToWorld;
                DisplayColor color = customColors[index];
                color.Color.Normalize();
                starConnectionsColors[index] = color;
            }
        }
        #endregion

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            m_StarLocalToWorlds = m_InstanceQuery.ToComponentDataArray<CustomLocalToWorld>(Allocator.TempJob, out inputDeps);
            inputDeps.Complete();
            m_CustomColors = m_InstanceQuery.ToComponentDataArray<DisplayColor>(Allocator.TempJob, out inputDeps);
            inputDeps.Complete();
            #region Draw stars
            if (m_EnableInstancedIndirect)
            {
                if (m_EnableGPUFrustumCulling)
                {
                    ToArray(m_StarLocalToWorlds, m_StarAmount, m_IndirectMatrices, 0);
                    ToArray(m_CustomColors, m_StarAmount, m_IndirectColors, 0);
                    m_LocalToWorldBuffer.SetData(m_IndirectMatrices);
                    m_EmissionColorBuffer.SetData(m_IndirectColors);
                    m_TransformationMatrixAppendBuffer.SetCounterValue(0);
                    DispatchSphereFrustumCalculation(m_StarMesh, m_LocalToWorldBuffer, m_TransformationMatrixAppendBuffer, m_StarAmount);
                    m_StarIndirectGPUCullingMaterial.SetBuffer("drawIndexBuffer", m_TransformationMatrixAppendBuffer);
                    m_StarIndirectGPUCullingMaterial.SetBuffer("localToWorldBuffer", m_LocalToWorldBuffer);
                    m_StarIndirectGPUCullingMaterial.SetBuffer("emissionColorBuffer", m_EmissionColorBuffer);
                    Graphics.DrawMeshInstancedIndirect(m_StarMesh, 0, m_StarIndirectGPUCullingMaterial, new Bounds(Vector3.zero, Vector3.one * 60000), m_ArgsBuffer, 0, null, 0, false, 0);
                }
                else
                {
                    ToArray(m_StarInfoList.AsArray(), m_StarInfoList.Length, m_StarRenderInfos, 0);
                    m_StarRenderInfoBuffer.SetData(m_StarRenderInfos);
                    m_StarIndirectMaterial.SetBuffer("starInfoBuffer", m_StarRenderInfoBuffer);
                    args[1] = (uint)m_StarInfoList.Length;
                    m_ArgsBuffer.SetData(args);
                    Graphics.DrawMeshInstancedIndirect(m_StarMesh, 0, m_StarIndirectMaterial, new Bounds(Vector3.zero, Vector3.one * 60000), m_ArgsBuffer, 0, null, 0, false, 0);
                    m_StarInfoList.Clear();
                }
            }
            else
            {
                //Here we use the normal Graphics.DrawMeshInstanced. It only support 1023 instances for 1 drawcall.
                int offset = 0;
                while (offset < StarAmount)
                {
                    if (StarAmount - offset > 1023)
                    {
                        NativeSlice<CustomLocalToWorld> slice = m_StarLocalToWorlds.Slice(offset, 1023);
                        NativeSlice<DisplayColor> colorSlice = m_CustomColors.Slice(offset, 1023);

                        ToArray(slice, 1023, m_Matrices, 0);
                        ToArray(colorSlice, 1023, m_Colors, 0);

                        m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", m_Colors);
                        Graphics.DrawMeshInstanced(m_StarMesh, 0, m_StarMaterial,
                            m_Matrices,
                            1023, m_MaterialPropertyBlock, 0, false, 0, null);
                        offset += 1023;
                    }
                    else
                    {
                        int amount = StarAmount - offset;
                        NativeSlice<CustomLocalToWorld> slice = m_StarLocalToWorlds.Slice(offset, amount);
                        NativeSlice<DisplayColor> colorSlice = m_CustomColors.Slice(offset, amount);

                        Matrix4x4[] matrices = new Matrix4x4[amount];
                        Vector4[] colors = new Vector4[amount];
                        ToArray(slice, amount, matrices, 0);
                        ToArray(colorSlice, amount, colors, 0);
                        m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", colors);

                        Graphics.DrawMeshInstanced(m_StarMesh, 0, m_StarMaterial,
                            matrices,
                            amount, m_MaterialPropertyBlock, 0, false, 0, null);
                        offset += StarAmount - offset;
                    }
                }
            }
            #endregion
            if (Input.GetKeyDown(KeyCode.C)) m_DrawConnections = !m_DrawConnections;
            if (Input.GetKeyDown(KeyCode.R)) ClearConnections();
            #region Draw connections
            if (m_DrawConnections && m_StarConnections.Length > 0)
            {
                inputDeps = new StarConnectionsGenerator
                {
                    customLocalToWorlds = m_StarLocalToWorlds,
                    customColors = m_CustomColors,
                    starConnectionsColors = m_StarConnectionsColors.AsDeferredJobArray(),
                    starConnections = m_StarConnections.AsDeferredJobArray(),
                    starConnectionsLocalToWorlds = m_StarConnectionsLocalToWorlds.AsDeferredJobArray(),
                    cameraPosition = m_Camera.transform.position,
                    widthFactor = 0.1f
                }.Schedule(m_StarConnections.Length, 1, inputDeps);
                inputDeps.Complete();
                if (false)
                {
                    int connectionAmount = m_StarConnections.Length;
                    m_LocalToWorldBuffer.SetData(m_StarConnectionsLocalToWorlds.ToArray());
                    m_EmissionColorBuffer.SetData(m_StarConnectionsColors.ToArray());
                    m_TransformationMatrixAppendBuffer.SetCounterValue(0);
                    DispatchOBBFrustumCalculation(m_StarConnectionMesh, m_LocalToWorldBuffer, m_TransformationMatrixAppendBuffer, connectionAmount);
                    m_StarIndirectGPUCullingMaterial.SetBuffer("drawIndexBuffer", m_TransformationMatrixAppendBuffer);
                    m_StarIndirectGPUCullingMaterial.SetBuffer("localToWorldBuffer", m_LocalToWorldBuffer);
                    m_StarIndirectGPUCullingMaterial.SetBuffer("emissionColorBuffer", m_EmissionColorBuffer);
                    Graphics.DrawMeshInstancedIndirect(m_StarConnectionMesh, 0, m_StarIndirectGPUCullingMaterial, new Bounds(Vector3.zero, Vector3.one * 60000), m_ArgsBuffer, 0, null, 0, false, 0);
                }
                else
                {
                    int offset = 0;
                    int connectionAmount = m_StarConnections.Length;
                    while (offset < connectionAmount)
                    {
                        if (connectionAmount - offset > 1023)
                        {
                            NativeSlice<CustomLocalToWorld> slice = m_StarConnectionsLocalToWorlds.AsArray().Slice(offset, 1023);
                            NativeSlice<DisplayColor> colorSlice = m_StarConnectionsColors.AsArray().Slice(offset, 1023);

                            ToArray(slice, 1023, m_Matrices, 0);
                            ToArray(colorSlice, 1023, m_Colors, 0);

                            m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", m_Colors);
                            Graphics.DrawMeshInstanced(m_StarConnectionMesh, 0, m_StarConnectionMaterial,
                                m_Matrices,
                                1023, m_MaterialPropertyBlock, 0, false, 0, null);
                            offset += 1023;
                        }
                        else
                        {
                            int amount = connectionAmount - offset;
                            NativeSlice<CustomLocalToWorld> slice = m_StarConnectionsLocalToWorlds.AsArray().Slice(offset, amount);
                            NativeSlice<DisplayColor> colorSlice = m_StarConnectionsColors.AsArray().Slice(offset, amount);

                            Matrix4x4[] matrices = new Matrix4x4[amount];
                            Vector4[] colors = new Vector4[amount];
                            ToArray(slice, amount, matrices, 0);
                            ToArray(colorSlice, amount, colors, 0);
                            m_MaterialPropertyBlock.SetVectorArray("_EmissionColor", colors);

                            Graphics.DrawMeshInstanced(m_StarConnectionMesh, 0, m_StarConnectionMaterial,
                                matrices,
                                amount, m_MaterialPropertyBlock, 0, false, 0, null);
                            offset += connectionAmount - offset;
                        }
                    }
                }
            }
            #endregion

            m_StarLocalToWorlds.Dispose();
            m_CustomColors.Dispose();

            return inputDeps;
        }
    }
}