; ModuleID = 'obj/Debug/android/marshal_methods.armeabi-v7a.ll'
source_filename = "obj/Debug/android/marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [288 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 88
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 122
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 9
	i32 39852199, ; 3: Plugin.Permissions => 0x26018a7 => 11
	i32 57263871, ; 4: Xamarin.Forms.Core.dll => 0x369c6ff => 113
	i32 57967248, ; 5: Xamarin.Android.Support.VersionedParcelable.dll => 0x3748290 => 56
	i32 101534019, ; 6: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 102
	i32 120558881, ; 7: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 102
	i32 148395041, ; 8: Lottie.Forms.dll => 0x8d85421 => 6
	i32 160529393, ; 9: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 31
	i32 165246403, ; 10: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 68
	i32 166922606, ; 11: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 41
	i32 182336117, ; 12: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 103
	i32 201930040, ; 13: Xamarin.Android.Arch.Core.Runtime => 0xc093538 => 32
	i32 209399409, ; 14: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 66
	i32 212497893, ; 15: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 116
	i32 230216969, ; 16: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 83
	i32 232815796, ; 17: System.Web.Services => 0xde07cb4 => 142
	i32 261689757, ; 18: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 71
	i32 278686392, ; 19: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 87
	i32 280482487, ; 20: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 81
	i32 293936332, ; 21: Xamarin.GooglePlayServices.Auth.Api.Phone.dll => 0x11851ccc => 123
	i32 318968648, ; 22: Xamarin.AndroidX.Activity.dll => 0x13031348 => 58
	i32 319314094, ; 23: Xamarin.Forms.Maps => 0x130858ae => 117
	i32 321597661, ; 24: System.Numerics => 0x132b30dd => 25
	i32 342366114, ; 25: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 85
	i32 347068432, ; 26: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 16
	i32 385762202, ; 27: System.Memory.dll => 0x16fe439a => 23
	i32 389971796, ; 28: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 43
	i32 441335492, ; 29: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 70
	i32 442521989, ; 30: Xamarin.Essentials => 0x1a605985 => 112
	i32 450948140, ; 31: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 80
	i32 465846621, ; 32: mscorlib => 0x1bc4415d => 8
	i32 469710990, ; 33: System.dll => 0x1bff388e => 21
	i32 476646585, ; 34: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 81
	i32 486930444, ; 35: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 92
	i32 514659665, ; 36: Xamarin.Android.Support.Compat => 0x1ead1551 => 41
	i32 524864063, ; 37: Xamarin.Android.Support.Print => 0x1f48ca3f => 53
	i32 526420162, ; 38: System.Transactions.dll => 0x1f6088c2 => 136
	i32 589597883, ; 39: Xamarin.GooglePlayServices.Auth.Api.Phone => 0x23248cbb => 123
	i32 605376203, ; 40: System.IO.Compression.FileSystem => 0x24154ecb => 140
	i32 627609679, ; 41: Xamarin.AndroidX.CustomView => 0x2568904f => 76
	i32 663517072, ; 42: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 108
	i32 666292255, ; 43: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 63
	i32 690569205, ; 44: System.Xml.Linq.dll => 0x29293ff5 => 30
	i32 692692150, ; 45: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 38
	i32 700284507, ; 46: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 130
	i32 719858431, ; 47: Bewize => 0x2ae82aff => 2
	i32 748832960, ; 48: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 14
	i32 775507847, ; 49: System.IO.Compression => 0x2e394f87 => 139
	i32 801787702, ; 50: Xamarin.Android.Support.Interpolator => 0x2fca4f36 => 50
	i32 809851609, ; 51: System.Drawing.Common.dll => 0x30455ad9 => 138
	i32 843511501, ; 52: Xamarin.AndroidX.Print => 0x3246f6cd => 99
	i32 902159924, ; 53: Rg.Plugins.Popup => 0x35c5de34 => 12
	i32 916714535, ; 54: Xamarin.Android.Support.Print.dll => 0x36a3f427 => 53
	i32 928116545, ; 55: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 122
	i32 955402788, ; 56: Newtonsoft.Json => 0x38f24a24 => 9
	i32 961995525, ; 57: Square.OkIO.dll => 0x3956e305 => 18
	i32 967690846, ; 58: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 85
	i32 974778368, ; 59: FormsViewGroup.dll => 0x3a19f000 => 3
	i32 987342438, ; 60: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0x3ad9a666 => 35
	i32 1012816738, ; 61: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 101
	i32 1035644815, ; 62: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 62
	i32 1042160112, ; 63: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 119
	i32 1052210849, ; 64: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 89
	i32 1084122840, ; 65: Xamarin.Kotlin.StdLib => 0x409e66d8 => 132
	i32 1098167829, ; 66: Xamarin.Android.Arch.Lifecycle.ViewModel => 0x4174b615 => 37
	i32 1098259244, ; 67: System => 0x41761b2c => 21
	i32 1118117278, ; 68: Plugin.GoogleClient => 0x42a51d9e => 10
	i32 1137654822, ; 69: Plugin.Permissions.dll => 0x43cf3c26 => 11
	i32 1175144683, ; 70: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 106
	i32 1178241025, ; 71: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 96
	i32 1204270330, ; 72: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 63
	i32 1267360935, ; 73: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 107
	i32 1292207520, ; 74: SQLitePCLRaw.core.dll => 0x4d0585a0 => 15
	i32 1292763917, ; 75: Xamarin.Android.Support.CursorAdapter.dll => 0x4d0e030d => 45
	i32 1293217323, ; 76: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 78
	i32 1297413738, ; 77: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0x4d54f66a => 34
	i32 1354490624, ; 78: Xamarin.Forms.GoogleMaps.dll => 0x50bbe300 => 115
	i32 1365406463, ; 79: System.ServiceModel.Internals.dll => 0x516272ff => 133
	i32 1371845985, ; 80: Xamarin.Forms.GoogleMaps.Android => 0x51c4b561 => 114
	i32 1376866003, ; 81: Xamarin.AndroidX.SavedState => 0x52114ed3 => 101
	i32 1395857551, ; 82: Xamarin.AndroidX.Media.dll => 0x5333188f => 93
	i32 1406073936, ; 83: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 72
	i32 1411638395, ; 84: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 27
	i32 1460219004, ; 85: Xamarin.Forms.Xaml => 0x57092c7c => 120
	i32 1462112819, ; 86: System.IO.Compression.dll => 0x57261233 => 139
	i32 1469204771, ; 87: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 61
	i32 1530663695, ; 88: Xamarin.Forms.Maps.dll => 0x5b3c130f => 117
	i32 1559433548, ; 89: Bewize.dll => 0x5cf3114c => 2
	i32 1574652163, ; 90: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 44
	i32 1582372066, ; 91: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 77
	i32 1587447679, ; 92: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 31
	i32 1592978981, ; 93: System.Runtime.Serialization.dll => 0x5ef2ee25 => 1
	i32 1622152042, ; 94: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 91
	i32 1624863272, ; 95: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 110
	i32 1636350590, ; 96: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 75
	i32 1639515021, ; 97: System.Net.Http.dll => 0x61b9038d => 24
	i32 1657153582, ; 98: System.Runtime => 0x62c6282e => 28
	i32 1658241508, ; 99: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 104
	i32 1658251792, ; 100: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 121
	i32 1670060433, ; 101: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 71
	i32 1687954387, ; 102: Bewize.Android => 0x649c23d3 => 0
	i32 1698840827, ; 103: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 131
	i32 1711441057, ; 104: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 16
	i32 1729485958, ; 105: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 67
	i32 1766324549, ; 106: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 103
	i32 1776026572, ; 107: System.Core.dll => 0x69dc03cc => 20
	i32 1788241197, ; 108: Xamarin.AndroidX.Fragment => 0x6a96652d => 80
	i32 1808609942, ; 109: Xamarin.AndroidX.Loader => 0x6bcd3296 => 91
	i32 1813058853, ; 110: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 132
	i32 1813201214, ; 111: Xamarin.Google.Android.Material => 0x6c13413e => 121
	i32 1818569960, ; 112: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 97
	i32 1866717392, ; 113: Xamarin.Android.Support.Interpolator.dll => 0x6f43d8d0 => 50
	i32 1867746548, ; 114: Xamarin.Essentials.dll => 0x6f538cf4 => 112
	i32 1878053835, ; 115: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 120
	i32 1881862856, ; 116: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 116
	i32 1885316902, ; 117: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 64
	i32 1908813208, ; 118: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 127
	i32 1916660109, ; 119: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x723de98d => 37
	i32 1919157823, ; 120: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 94
	i32 1983156543, ; 121: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 131
	i32 2005254497, ; 122: Bewize.Android.dll => 0x7785c161 => 0
	i32 2011961780, ; 123: System.Buffers.dll => 0x77ec19b4 => 19
	i32 2019465201, ; 124: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 89
	i32 2037417872, ; 125: Xamarin.Android.Support.ViewPager => 0x79708790 => 57
	i32 2044222327, ; 126: Xamarin.Android.Support.Loader => 0x79d85b77 => 51
	i32 2055257422, ; 127: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 86
	i32 2079903147, ; 128: System.Runtime.dll => 0x7bf8cdab => 28
	i32 2090596640, ; 129: System.Numerics.Vectors => 0x7c9bf920 => 26
	i32 2095474518, ; 130: Xamarin.GooglePlayServices.Auth.Base => 0x7ce66756 => 124
	i32 2097448633, ; 131: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 82
	i32 2103459038, ; 132: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 17
	i32 2126786730, ; 133: Xamarin.Forms.Platform.Android => 0x7ec430aa => 118
	i32 2129483829, ; 134: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 126
	i32 2139458754, ; 135: Xamarin.Android.Support.DrawerLayout => 0x7f858cc2 => 49
	i32 2166116741, ; 136: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 44
	i32 2188064486, ; 137: System.Json.dll => 0x826b36e6 => 22
	i32 2196165013, ; 138: Xamarin.Android.Support.VersionedParcelable => 0x82e6d195 => 56
	i32 2201231467, ; 139: System.Net.Http => 0x8334206b => 24
	i32 2217644978, ; 140: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 106
	i32 2244775296, ; 141: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 92
	i32 2256548716, ; 142: Xamarin.AndroidX.MultiDex => 0x8680336c => 94
	i32 2261435625, ; 143: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 84
	i32 2279755925, ; 144: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 100
	i32 2315684594, ; 145: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 59
	i32 2330457430, ; 146: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 43
	i32 2330986192, ; 147: Xamarin.Android.Support.SlidingPaneLayout.dll => 0x8af006d0 => 54
	i32 2409053734, ; 148: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 98
	i32 2440966767, ; 149: Xamarin.Android.Support.Loader.dll => 0x917e326f => 51
	i32 2445024337, ; 150: Xamarin.Forms.GoogleMaps.Android.dll => 0x91bc1c51 => 114
	i32 2465273461, ; 151: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 14
	i32 2465532216, ; 152: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 70
	i32 2471841756, ; 153: netstandard.dll => 0x93554fdc => 134
	i32 2475788418, ; 154: Java.Interop.dll => 0x93918882 => 4
	i32 2487632829, ; 155: Xamarin.Android.Support.DocumentFile => 0x944643bd => 48
	i32 2501346920, ; 156: System.Data.DataSetExtensions => 0x95178668 => 137
	i32 2505896520, ; 157: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 88
	i32 2581819634, ; 158: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 107
	i32 2620871830, ; 159: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 75
	i32 2624644809, ; 160: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 79
	i32 2633051222, ; 161: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 87
	i32 2698266930, ; 162: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa0d44932 => 35
	i32 2701096212, ; 163: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 104
	i32 2732626843, ; 164: Xamarin.AndroidX.Activity => 0xa2e0939b => 58
	i32 2737747696, ; 165: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 61
	i32 2751899777, ; 166: Xamarin.Android.Support.Collections => 0xa406a881 => 40
	i32 2766581644, ; 167: Xamarin.Forms.Core => 0xa4e6af8c => 113
	i32 2770495804, ; 168: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 130
	i32 2778768386, ; 169: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 109
	i32 2782647110, ; 170: Xamarin.Android.Support.CustomTabs.dll => 0xa5dbd346 => 46
	i32 2788639665, ; 171: Xamarin.Android.Support.LocalBroadcastManager => 0xa63743b1 => 52
	i32 2788775637, ; 172: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0xa63956d5 => 55
	i32 2810250172, ; 173: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 72
	i32 2819470561, ; 174: System.Xml.dll => 0xa80db4e1 => 29
	i32 2843355708, ; 175: Lottie.Android.dll => 0xa97a2a3c => 5
	i32 2847418871, ; 176: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 126
	i32 2853208004, ; 177: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 109
	i32 2855708567, ; 178: Xamarin.AndroidX.Transition => 0xaa36a797 => 105
	i32 2861816565, ; 179: Rg.Plugins.Popup.dll => 0xaa93daf5 => 12
	i32 2876493027, ; 180: Xamarin.Android.Support.SwipeRefreshLayout => 0xab73cce3 => 55
	i32 2893257763, ; 181: Xamarin.Android.Arch.Core.Runtime.dll => 0xac739c23 => 32
	i32 2903344695, ; 182: System.ComponentModel.Composition => 0xad0d8637 => 141
	i32 2905242038, ; 183: mscorlib.dll => 0xad2a79b6 => 8
	i32 2916838712, ; 184: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 110
	i32 2919462931, ; 185: System.Numerics.Vectors.dll => 0xae037813 => 26
	i32 2921128767, ; 186: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 60
	i32 2921692953, ; 187: Xamarin.Android.Support.CustomView.dll => 0xae257f19 => 47
	i32 2943219317, ; 188: Square.OkIO => 0xaf6df675 => 18
	i32 2978675010, ; 189: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 78
	i32 3017076677, ; 190: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 128
	i32 3024354802, ; 191: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 83
	i32 3044182254, ; 192: FormsViewGroup => 0xb57288ee => 3
	i32 3056250942, ; 193: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0xb62ab03e => 39
	i32 3057625584, ; 194: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 95
	i32 3058099980, ; 195: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 129
	i32 3068715062, ; 196: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 33
	i32 3111772706, ; 197: System.Runtime.Serialization => 0xb979e222 => 1
	i32 3191408315, ; 198: Xamarin.Android.Support.CustomTabs => 0xbe3906bb => 46
	i32 3201217166, ; 199: System.Json => 0xbeceb28e => 22
	i32 3204380047, ; 200: System.Data.dll => 0xbefef58f => 135
	i32 3204912593, ; 201: Xamarin.Android.Support.AsyncLayoutInflater => 0xbf0715d1 => 39
	i32 3211777861, ; 202: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 77
	i32 3230466174, ; 203: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 127
	i32 3233339011, ; 204: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xc0b8d683 => 34
	i32 3247949154, ; 205: Mono.Security => 0xc197c562 => 143
	i32 3258312781, ; 206: Xamarin.AndroidX.CardView => 0xc235e84d => 67
	i32 3263631797, ; 207: Lottie.Forms => 0xc28711b5 => 6
	i32 3267021929, ; 208: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 65
	i32 3286872994, ; 209: SQLite-net.dll => 0xc3e9b3a2 => 13
	i32 3296380511, ; 210: Xamarin.Android.Support.Collections.dll => 0xc47ac65f => 40
	i32 3317135071, ; 211: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 76
	i32 3317144872, ; 212: System.Data => 0xc5b79d28 => 135
	i32 3321585405, ; 213: Xamarin.Android.Support.DocumentFile.dll => 0xc5fb5efd => 48
	i32 3340431453, ; 214: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 64
	i32 3346324047, ; 215: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 96
	i32 3352662376, ; 216: Xamarin.Android.Support.CoordinaterLayout => 0xc7d59168 => 42
	i32 3353484488, ; 217: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 82
	i32 3357663996, ; 218: Xamarin.Android.Support.CursorAdapter => 0xc821e2fc => 45
	i32 3360279109, ; 219: SQLitePCLRaw.core => 0xc849ca45 => 15
	i32 3362522851, ; 220: Xamarin.AndroidX.Core => 0xc86c06e3 => 74
	i32 3366347497, ; 221: Java.Interop => 0xc8a662e9 => 4
	i32 3374999561, ; 222: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 100
	i32 3384801434, ; 223: Xamarin.Auth.dll => 0xc9bff89a => 111
	i32 3395150330, ; 224: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 27
	i32 3404865022, ; 225: System.ServiceModel.Internals => 0xcaf21dfe => 133
	i32 3429136800, ; 226: System.Xml => 0xcc6479a0 => 29
	i32 3430777524, ; 227: netstandard => 0xcc7d82b4 => 134
	i32 3439690031, ; 228: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 38
	i32 3441283291, ; 229: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 79
	i32 3459516321, ; 230: Xamarin.Forms.GoogleMaps => 0xce3407a1 => 115
	i32 3465947803, ; 231: Xamarin.GooglePlayServices.Auth.dll => 0xce962a9b => 125
	i32 3476120550, ; 232: Mono.Android => 0xcf3163e6 => 7
	i32 3486566296, ; 233: System.Transactions => 0xcfd0c798 => 136
	i32 3493954962, ; 234: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 69
	i32 3501239056, ; 235: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 65
	i32 3509114376, ; 236: System.Xml.Linq => 0xd128d608 => 30
	i32 3536029504, ; 237: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 118
	i32 3547625832, ; 238: Xamarin.Android.Support.SlidingPaneLayout => 0xd3747968 => 54
	i32 3567349600, ; 239: System.ComponentModel.Composition.dll => 0xd4a16f60 => 141
	i32 3618140916, ; 240: Xamarin.AndroidX.Preference => 0xd7a872f4 => 98
	i32 3627220390, ; 241: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 99
	i32 3632359727, ; 242: Xamarin.Forms.Platform => 0xd881692f => 119
	i32 3633644679, ; 243: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 60
	i32 3639449509, ; 244: Lottie.Android => 0xd8ed97a5 => 5
	i32 3641597786, ; 245: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 86
	i32 3664423555, ; 246: Xamarin.Android.Support.ViewPager.dll => 0xda6aaa83 => 57
	i32 3672681054, ; 247: Mono.Android.dll => 0xdae8aa5e => 7
	i32 3676310014, ; 248: System.Web.Services.dll => 0xdb2009fe => 142
	i32 3681174138, ; 249: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 33
	i32 3682565725, ; 250: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 66
	i32 3684561358, ; 251: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 69
	i32 3689375977, ; 252: System.Drawing.Common => 0xdbe768e9 => 138
	i32 3700443353, ; 253: Plugin.GoogleClient.dll => 0xdc9048d9 => 10
	i32 3706696989, ; 254: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 73
	i32 3714038699, ; 255: Xamarin.Android.Support.LocalBroadcastManager.dll => 0xdd5fbbab => 52
	i32 3718780102, ; 256: Xamarin.AndroidX.Annotation => 0xdda814c6 => 59
	i32 3724971120, ; 257: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 95
	i32 3729924096, ; 258: Xamarin.GooglePlayServices.Auth => 0xde522000 => 125
	i32 3754567612, ; 259: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 17
	i32 3758932259, ; 260: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 84
	i32 3776062606, ; 261: Xamarin.Android.Support.DrawerLayout.dll => 0xe112248e => 49
	i32 3786282454, ; 262: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 68
	i32 3822602673, ; 263: Xamarin.AndroidX.Media => 0xe3d849b1 => 93
	i32 3829621856, ; 264: System.Numerics.dll => 0xe4436460 => 25
	i32 3832731800, ; 265: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe472d898 => 42
	i32 3862817207, ; 266: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 36
	i32 3874897629, ; 267: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 36
	i32 3876362041, ; 268: SQLite-net => 0xe70c9739 => 13
	i32 3885922214, ; 269: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 105
	i32 3896760992, ; 270: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 74
	i32 3920810846, ; 271: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 140
	i32 3921031405, ; 272: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 108
	i32 3931092270, ; 273: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 97
	i32 3945713374, ; 274: System.Data.DataSetExtensions.dll => 0xeb2ecede => 137
	i32 3955647286, ; 275: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 62
	i32 3970018735, ; 276: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 129
	i32 3991193666, ; 277: Xamarin.GooglePlayServices.Auth.Base.dll => 0xede4c842 => 124
	i32 4014452692, ; 278: Xamarin.Auth => 0xef47afd4 => 111
	i32 4025784931, ; 279: System.Memory => 0xeff49a63 => 23
	i32 4063435586, ; 280: Xamarin.Android.Support.CustomView => 0xf2331b42 => 47
	i32 4105002889, ; 281: Mono.Security.dll => 0xf4ad5f89 => 143
	i32 4151237749, ; 282: System.Core => 0xf76edc75 => 20
	i32 4182413190, ; 283: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 90
	i32 4256097574, ; 284: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 73
	i32 4260525087, ; 285: System.Buffers => 0xfdf2741f => 19
	i32 4278134329, ; 286: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 128
	i32 4292120959 ; 287: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 90
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [288 x i32] [
	i32 88, i32 122, i32 9, i32 11, i32 113, i32 56, i32 102, i32 102, ; 0..7
	i32 6, i32 31, i32 68, i32 41, i32 103, i32 32, i32 66, i32 116, ; 8..15
	i32 83, i32 142, i32 71, i32 87, i32 81, i32 123, i32 58, i32 117, ; 16..23
	i32 25, i32 85, i32 16, i32 23, i32 43, i32 70, i32 112, i32 80, ; 24..31
	i32 8, i32 21, i32 81, i32 92, i32 41, i32 53, i32 136, i32 123, ; 32..39
	i32 140, i32 76, i32 108, i32 63, i32 30, i32 38, i32 130, i32 2, ; 40..47
	i32 14, i32 139, i32 50, i32 138, i32 99, i32 12, i32 53, i32 122, ; 48..55
	i32 9, i32 18, i32 85, i32 3, i32 35, i32 101, i32 62, i32 119, ; 56..63
	i32 89, i32 132, i32 37, i32 21, i32 10, i32 11, i32 106, i32 96, ; 64..71
	i32 63, i32 107, i32 15, i32 45, i32 78, i32 34, i32 115, i32 133, ; 72..79
	i32 114, i32 101, i32 93, i32 72, i32 27, i32 120, i32 139, i32 61, ; 80..87
	i32 117, i32 2, i32 44, i32 77, i32 31, i32 1, i32 91, i32 110, ; 88..95
	i32 75, i32 24, i32 28, i32 104, i32 121, i32 71, i32 0, i32 131, ; 96..103
	i32 16, i32 67, i32 103, i32 20, i32 80, i32 91, i32 132, i32 121, ; 104..111
	i32 97, i32 50, i32 112, i32 120, i32 116, i32 64, i32 127, i32 37, ; 112..119
	i32 94, i32 131, i32 0, i32 19, i32 89, i32 57, i32 51, i32 86, ; 120..127
	i32 28, i32 26, i32 124, i32 82, i32 17, i32 118, i32 126, i32 49, ; 128..135
	i32 44, i32 22, i32 56, i32 24, i32 106, i32 92, i32 94, i32 84, ; 136..143
	i32 100, i32 59, i32 43, i32 54, i32 98, i32 51, i32 114, i32 14, ; 144..151
	i32 70, i32 134, i32 4, i32 48, i32 137, i32 88, i32 107, i32 75, ; 152..159
	i32 79, i32 87, i32 35, i32 104, i32 58, i32 61, i32 40, i32 113, ; 160..167
	i32 130, i32 109, i32 46, i32 52, i32 55, i32 72, i32 29, i32 5, ; 168..175
	i32 126, i32 109, i32 105, i32 12, i32 55, i32 32, i32 141, i32 8, ; 176..183
	i32 110, i32 26, i32 60, i32 47, i32 18, i32 78, i32 128, i32 83, ; 184..191
	i32 3, i32 39, i32 95, i32 129, i32 33, i32 1, i32 46, i32 22, ; 192..199
	i32 135, i32 39, i32 77, i32 127, i32 34, i32 143, i32 67, i32 6, ; 200..207
	i32 65, i32 13, i32 40, i32 76, i32 135, i32 48, i32 64, i32 96, ; 208..215
	i32 42, i32 82, i32 45, i32 15, i32 74, i32 4, i32 100, i32 111, ; 216..223
	i32 27, i32 133, i32 29, i32 134, i32 38, i32 79, i32 115, i32 125, ; 224..231
	i32 7, i32 136, i32 69, i32 65, i32 30, i32 118, i32 54, i32 141, ; 232..239
	i32 98, i32 99, i32 119, i32 60, i32 5, i32 86, i32 57, i32 7, ; 240..247
	i32 142, i32 33, i32 66, i32 69, i32 138, i32 10, i32 73, i32 52, ; 248..255
	i32 59, i32 95, i32 125, i32 17, i32 84, i32 49, i32 68, i32 93, ; 256..263
	i32 25, i32 42, i32 36, i32 36, i32 13, i32 105, i32 74, i32 140, ; 264..271
	i32 108, i32 97, i32 137, i32 62, i32 129, i32 124, i32 111, i32 23, ; 272..279
	i32 47, i32 143, i32 20, i32 90, i32 73, i32 19, i32 128, i32 90 ; 288..287
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
