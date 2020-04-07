namespace TabbyCat.Common.Types
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// https://www.khronos.org/registry/OpenGL/specs/gl/GLSLangSpec.4.60.pdf
    /// </summary>
    public static class GLSL
    {
        #region Private Fields

        private static readonly string[]

            _Directives = new[]
            {
                "define", "elif", "else", "endif", "error", "extension", "if", "ifdef", "ifndef",
                "line", "pragma", "undef", "version"
            },

            _Functions = new[]
            {
                "abs", "acos", "acosh", "all", "allInvocations", "allInvocationsEqual", "any",
                "anyInvocation", "asin", "asinh", "atan", "atanh", "atomicAdd", "atomicAnd",
                "atomicCompSwap", "atomicCounter", "atomicCounterAdd", "atomicCounterAnd",
                "atomicCounterCompSwap", "atomicCounterDecrement", "atomicCounterExchange",
                "atomicCounterIncrement", "atomicCounterMax", "atomicCounterMin", "atomicCounterOr",
                "atomicCounterSubtract", "atomicCounterXor", "atomicExchange", "atomicMax",
                "atomicMin", "atomicOr", "atomicXor", "barrier", "bitCount", "bitFieldExtract",
                "bitFieldInsert", "bitFieldReverse", "ceil", "clamp", "cos", "cosh", "cross",
                "degrees", "determinant", "dFdx", "dFdxCoarse", "dFdxFine", "dFdy", "dFdyCoarse",
                "dFdyFine", "distance", "dot", "EmitStreamVertex", "EmitVertex", "EndPrimitive",
                "EndStreamPrimitive", "equal", "exp", "exp2", "faceforward", "findLSB", "findMSB",
                "floatBitsToInt", "floatBitsToUint", "floor", "fma", "fract", "frexp", "ftransform",
                "fwidth", "fwidthCoarse", "fwidthFine", "greaterThan", "greaterThanEqual",
                "groupMemoryBarrier", "imageAtomicAdd", "imageAtomicAnd", "imageAtomicCompSwap",
                "imageAtomicExchange", "imageAtomicMax", "imageAtomicMin", "imageAtomicOr",
                "imageAtomicXor", "imageLoad", "imageSamples", "imageSize", "imageStore",
                "imulExtended", "intBitsToFloat", "interpolateAtCentroid", "interpolateAtOffset",
                "interpolateAtSample", "inverse", "inversesqrt", "isinf", "isnan", "ldexp",
                "length", "lessThan", "lessThanEqual", "log", "log2", "matrixCompMult", "max",
                "memoryBarrier", "memoryBarrierAtomicCounter", "memoryBarrierBuffer",
                "memoryBarrierImage", "memoryBarrierShared", "min", "mix", "mod", "modf", "noise1",
                "noise2", "noise3", "noise4", "normalize", "not", "notEqual", "outerProduct",
                "packDouble2x32", "packHalf2x16", "packSnorm2x16", "packSnorm4x8", "packUnorm2x16",
                "packUnorm4x8", "pow", "radians", "reflect", "refract", "round", "roundEven",
                "shadow1D", "shadow1DLod", "shadow1DProj", "shadow1DProjLod", "shadow2D",
                "shadow2DLod", "shadow2DProj", "shadow2DProjLod", "sign", "sin", "sinh",
                "smoothstep", "sqrt", "step", "subpassLoad", "tan", "tanh", "texelFetch",
                "texelFetchOffset", "texture", "texture1D", "texture1DLod", "texture1DProj",
                "texture1DProjLod", "texture2D", "texture2DLod", "texture2DProj",
                "texture2DProjLod", "texture3D", "texture3DLod", "texture3DProj",
                "texture3DProjLod", "textureCube", "textureCubeLod", "textureGather",
                "textureGatherOffset", "textureGatherOffsets", "textureGrad",
                "textureGradOffset", "textureLod", "textureLodOffset", "textureOffset",
                "textureProj", "textureProjGrad", "textureProjGradOffset", "textureProjLod",
                "textureProjLodOffset", "textureProjOffset", "textureQueryLevels",
                "textureQueryLod", "textureSize", "transpose", "trunc", "uaddCarry",
                "uintBitsToFloat", "umulExtended", "unpackDouble2x32", "unpackHalf2x16",
                "unpackSnorm2x16", "unpackSnorm4x8", "unpackUnorm2x16", "unpackUnorm4x8",
                "usubBorrow"
            },

            _Keywords = new[]
            {
                "atomic_uint", "attribute", "bool", "break", "buffer", "bvec2", "bvec3", "bvec4",
                "case", "centroid", "coherent", "const", "continue", "default", "discard", "dmat2",
                "dmat2x2", "dmat2x3", "dmat2x4", "dmat3", "dmat3x2", "dmat3x3", "dmat3x4", "dmat4",
                "dmat4x2", "dmat4x3", "dmat4x4", "do", "double", "dvec2", "dvec3", "dvec4", "else",
                "false", "flat", "float", "for", "highp", "if", "iimage1D", "iimage1DArray",
                "iimage2D", "iimage2DArray", "iimage2DMS", "iimage2DMSArray", "iimage2DRect",
                "iimage3D", "iimageBuffer", "iimageCube", "iimageCubeArray", "image1D",
                "image1DArray", "image2D", "image2DArray", "image2DMS", "image2DMSArray",
                "image2DRect", "image3D", "imageBuffer", "imageCube", "imageCubeArray", "in",
                "inout", "int", "invariant", "isampler1D", "isampler1DArray", "isampler2D",
                "isampler2DArray", "isampler2DMS", "isampler2DMSArray", "isampler2DRect",
                "isampler3D", "isamplerBuffer", "isamplerCube", "isamplerCubeArray",
                "isubpassInput", "isubpassInputMS", "itexture1D", "itexture1DArray", "itexture2D",
                "itexture2DArray", "itexture2DMS", "itexture2DMSArray", "itexture2DRect",
                "itexture3D", "itextureBuffer", "itextureCube", "itextureCubeArray", "ivec2",
                "ivec3", "ivec4", "layout", "lowp", "mat2", "mat2x2", "mat2x3", "mat2x4", "mat3",
                "mat3x2", "mat3x3", "mat3x4", "mat4", "mat4x2", "mat4x3", "mat4x4", "mediump",
                "noperspective", "out", "patch", "precise", "precision", "readonly", "restrict",
                "return", "sample", "sampler", "sampler1D", "sampler1DArray",
                "sampler1DArrayShadow", "sampler1DShadow", "sampler2D", "sampler2DArray",
                "sampler2DArrayShadow", "sampler2DMS", "sampler2DMSArray", "sampler2DRect",
                "sampler2DRectShadow", "sampler2DShadow", "sampler3D", "samplerBuffer",
                "samplerCube", "samplerCubeArray", "samplerCubeArrayShadow", "samplerCubeShadow",
                "samplerShadow", "shared", "smooth", "struct", "subpassInput", "subpassInputMS",
                "subroutine", "switch", "texture1D", "texture1DArray", "texture2D",
                "texture2DArray", "texture2DMS", "texture2DMSArray", "texture2DRect", "texture3D",
                "textureBuffer", "textureCube", "textureCubeArray", "true", "uimage1D",
                "uimage1DArray", "uimage2D", "uimage2DArray", "uimage2DMS", "uimage2DMSArray",
                "uimage2DRect", "uimage3D", "uimageBuffer", "uimageCube", "uimageCubeArray", "uint",
                "uniform", "usampler1D", "usampler1DArray", "usampler2D", "usampler2DArray",
                "usampler2DMS", "usampler2DMSArray", "usampler2DRect", "usampler3D",
                "usamplerBuffer", "usamplerCube", "usamplerCubeArray", "usubpassInput",
                "usubpassInputMS", "utexture1D", "utexture1DArray", "utexture2D", "utexture2DArray",
                "utexture2DMS", "utexture2DMSArray", "utexture2DRect", "utexture3D",
                "utextureBuffer", "utextureCube", "utextureCubeArray", "uvec2", "uvec3", "uvec4",
                "varying", "vec2", "vec3", "vec4", "void", "volatile", "while", "writeonly"
            },

            _ReservedWords = new[]
            {
                "active", "asm", "cast", "class", "common", "enum", "extern", "external", "filter",
                "fixed", "fvec2", "fvec3", "fvec4", "goto", "half", "hvec2", "hvec3", "hvec4",
                "inline", "input", "interface", "long", "namespace", "noinline", "output",
                "partition", "public", "resource", "sampler3DRect", "short", "sizeof", "static",
                "superp", "template", "this", "typedef", "union", "unsigned", "using"
            };

        #endregion

        #region Public Fields

        public const string
            Comments1 = @"//.*$",
            Comments2 = @"(/\*.*?\*/)|(/\*.*)",
            Comments3 = @"(/\*.*?\*/)|(.*\*/)",
            Numbers = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b",
            Strings = @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'";

        public static readonly string
            Directives = $@"#\s*{Concat(_Directives)}\b",
            Functions = $@"\b{Concat(_Functions)}\b",
            Keywords = $@"\b{Concat(_Keywords)}\b",
            ReservedWords = $@"\b{Concat(_ReservedWords)}\b";

        public static List<string> AutocompleteItems =
            _Directives.Select(p => $"#{p}").Union(_Functions).Union(_Keywords).ToList();

        #endregion

        #region Private Methods

        private static string Concat(IEnumerable<string> words) =>
            string.Concat("(", words.Aggregate((s, t) => $"{s}|{t}"), ")");

        #endregion
    }
}
