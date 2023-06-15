; ModuleID = 'obj/Debug/android/marshal_methods.arm64-v8a.ll'
source_filename = "obj/Debug/android/marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [288 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 79
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 7
	i64 210515253464952879, ; 2: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 68
	i64 232391251801502327, ; 3: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 101
	i64 263803244706540312, ; 4: Rg.Plugins.Popup.dll => 0x3a937a743542b18 => 12
	i64 276473666272823710, ; 5: Xamarin.Forms.GoogleMaps => 0x3d63b55abf1099e => 115
	i64 295915112840604065, ; 6: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 102
	i64 316157742385208084, ; 7: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 73
	i64 590536689428908136, ; 8: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x83201fd803ec868 => 37
	i64 634308326490598313, ; 9: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 88
	i64 687654259221141486, ; 10: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 126
	i64 702024105029695270, ; 11: System.Drawing.Common => 0x9be17343c0e7726 => 138
	i64 720058930071658100, ; 12: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 82
	i64 816102801403336439, ; 13: Xamarin.Android.Support.Collections => 0xb53612c89d8d6f7 => 40
	i64 846634227898301275, ; 14: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0xbbfd9583890bb5b => 34
	i64 870603111519317375, ; 15: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 16
	i64 872800313462103108, ; 16: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 78
	i64 940822596282819491, ; 17: System.Transactions => 0xd0e792aa81923a3 => 136
	i64 996343623809489702, ; 18: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 119
	i64 1000557547492888992, ; 19: Mono.Security.dll => 0xde2b1c9cba651a0 => 143
	i64 1120440138749646132, ; 20: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 121
	i64 1279005280680051172, ; 21: Bewize.Android => 0x11bff086bcc881e4 => 0
	i64 1301485588176585670, ; 22: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 15
	i64 1315114680217950157, ; 23: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 63
	i64 1400031058434376889, ; 24: Plugin.Permissions.dll => 0x136de8d4787ec4b9 => 11
	i64 1425944114962822056, ; 25: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 1
	i64 1490981186906623721, ; 26: Xamarin.Android.Support.VersionedParcelable => 0x14b1077d6c5c0ee9 => 56
	i64 1518315023656898250, ; 27: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 17
	i64 1624659445732251991, ; 28: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 61
	i64 1628611045998245443, ; 29: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 90
	i64 1636321030536304333, ; 30: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 83
	i64 1731380447121279447, ; 31: Newtonsoft.Json => 0x18071957e9b889d7 => 9
	i64 1743969030606105336, ; 32: System.Memory.dll => 0x1833d297e88f2af8 => 23
	i64 1795316252682057001, ; 33: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 62
	i64 1836611346387731153, ; 34: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 101
	i64 1875917498431009007, ; 35: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 59
	i64 1981742497975770890, ; 36: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 89
	i64 2133195048986300728, ; 37: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 9
	i64 2136356949452311481, ; 38: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 94
	i64 2165725771938924357, ; 39: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 66
	i64 2262844636196693701, ; 40: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 78
	i64 2284400282711631002, ; 41: System.Web.Services => 0x1fb3d1f42fd4249a => 142
	i64 2329709569556905518, ; 42: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 86
	i64 2337758774805907496, ; 43: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 27
	i64 2470498323731680442, ; 44: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 72
	i64 2479423007379663237, ; 45: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 106
	i64 2497223385847772520, ; 46: System.Runtime => 0x22a7eb7046413568 => 28
	i64 2541787113603107559, ; 47: Lottie.Android.dll => 0x23463de9b0fa8ae7 => 5
	i64 2547086958574651984, ; 48: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 58
	i64 2592350477072141967, ; 49: System.Xml.dll => 0x23f9e10627330e8f => 29
	i64 2624866290265602282, ; 50: mscorlib.dll => 0x246d65fbde2db8ea => 8
	i64 2694427813909235223, ; 51: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 98
	i64 2783046991838674048, ; 52: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 27
	i64 2949706848458024531, ; 53: Xamarin.Android.Support.SlidingPaneLayout => 0x28ef76c01de0a653 => 54
	i64 2954987430423977617, ; 54: Xamarin.GooglePlayServices.Auth.Base => 0x290239696a2a5e91 => 124
	i64 2960931600190307745, ; 55: Xamarin.Forms.Core => 0x2917579a49927da1 => 113
	i64 2977248461349026546, ; 56: Xamarin.Android.Support.DrawerLayout => 0x29514fb392c97af2 => 49
	i64 3017704767998173186, ; 57: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 121
	i64 3171992396844006720, ; 58: Square.OkIO => 0x2c052e476c207d40 => 18
	i64 3260998928894807349, ; 59: Lottie.Forms.dll => 0x2d41653f91b44d35 => 6
	i64 3289520064315143713, ; 60: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 85
	i64 3303437397778967116, ; 61: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 60
	i64 3311221304742556517, ; 62: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 26
	i64 3411255996856937470, ; 63: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 127
	i64 3427548605411023127, ; 64: Xamarin.GooglePlayServices.Auth.Api.Phone.dll => 0x2f91194bf3e8d917 => 123
	i64 3429364154853028534, ; 65: Plugin.GoogleClient => 0x2f978c877f78f2b6 => 10
	i64 3493805808809882663, ; 66: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 104
	i64 3494805765830528351, ; 67: Bewize.dll => 0x30800b53e750cd5f => 2
	i64 3522470458906976663, ; 68: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 103
	i64 3531994851595924923, ; 69: System.Numerics => 0x31042a9aade235bb => 25
	i64 3571415421602489686, ; 70: System.Runtime.dll => 0x319037675df7e556 => 28
	i64 3716579019761409177, ; 71: netstandard.dll => 0x3393f0ed5c8c5c99 => 134
	i64 3727469159507183293, ; 72: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 100
	i64 3772598417116884899, ; 73: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 79
	i64 3936216335706411319, ; 74: Xamarin.Forms.GoogleMaps.dll => 0x36a03fe700ded137 => 115
	i64 3966267475168208030, ; 75: System.Memory => 0x370b03412596249e => 23
	i64 4188590420490812999, ; 76: Plugin.GoogleClient.dll => 0x3a20dccb9af57e47 => 10
	i64 4201423742386704971, ; 77: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 73
	i64 4247996603072512073, ; 78: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 129
	i64 4252163538099460320, ; 79: Xamarin.Android.Support.ViewPager.dll => 0x3b02b8357f4958e0 => 57
	i64 4337444564132831293, ; 80: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 14
	i64 4349341163892612332, ; 81: Xamarin.Android.Support.DocumentFile => 0x3c5bf6bea8cd9cec => 48
	i64 4416987920449902723, ; 82: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0x3d4c4b1c879b9883 => 39
	i64 4518339170339332403, ; 83: Xamarin.Auth.dll => 0x3eb45d8946cf2133 => 111
	i64 4525561845656915374, ; 84: System.ServiceModel.Internals => 0x3ece06856b710dae => 133
	i64 4636684751163556186, ; 85: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 108
	i64 4782108999019072045, ; 86: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 65
	i64 4794310189461587505, ; 87: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 58
	i64 4794713372925163451, ; 88: Xamarin.Auth => 0x428a3e68c104f7bb => 111
	i64 4795410492532947900, ; 89: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 103
	i64 4841234827713643511, ; 90: Xamarin.Android.Support.CoordinaterLayout => 0x432f856d041f03f7 => 42
	i64 4963205065368577818, ; 91: Xamarin.Android.Support.LocalBroadcastManager.dll => 0x44e0d8b5f4b6a71a => 52
	i64 5142919913060024034, ; 92: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 118
	i64 5178572682164047940, ; 93: Xamarin.Android.Support.Print.dll => 0x47ddfc6acbee1044 => 53
	i64 5203618020066742981, ; 94: Xamarin.Essentials => 0x4836f704f0e652c5 => 112
	i64 5205316157927637098, ; 95: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 92
	i64 5256995213548036366, ; 96: Xamarin.Forms.Maps.Android.dll => 0x48f4994b4175a10e => 116
	i64 5258427006098912452, ; 97: Xamarin.GooglePlayServices.Auth.Base.dll => 0x48f9af806fd8b4c4 => 124
	i64 5288341611614403055, ; 98: Xamarin.Android.Support.Interpolator.dll => 0x4963f6ad4b3179ef => 50
	i64 5348796042099802469, ; 99: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 93
	i64 5376510917114486089, ; 100: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 106
	i64 5408338804355907810, ; 101: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 105
	i64 5451019430259338467, ; 102: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 71
	i64 5507995362134886206, ; 103: System.Core.dll => 0x4c705499688c873e => 20
	i64 5692067934154308417, ; 104: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 110
	i64 5757522595884336624, ; 105: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 69
	i64 5767696078500135884, ; 106: Xamarin.Android.Support.Annotations.dll => 0x500af9065b6a03cc => 38
	i64 5814345312393086621, ; 107: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 98
	i64 5896680224035167651, ; 108: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 87
	i64 6044705416426755068, ; 109: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0x53e31b8ccdff13fc => 55
	i64 6085203216496545422, ; 110: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 119
	i64 6086316965293125504, ; 111: FormsViewGroup.dll => 0x5476f10882baef80 => 3
	i64 6183170893902868313, ; 112: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 14
	i64 6311200438583329442, ; 113: Xamarin.Android.Support.LocalBroadcastManager => 0x5795e35c580c82a2 => 52
	i64 6319713645133255417, ; 114: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 88
	i64 6401687960814735282, ; 115: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 86
	i64 6504860066809920875, ; 116: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 66
	i64 6548213210057960872, ; 117: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 76
	i64 6591024623626361694, ; 118: System.Web.Services.dll => 0x5b7805f9751a1b5e => 142
	i64 6659513131007730089, ; 119: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 82
	i64 6876862101832370452, ; 120: System.Xml.Linq => 0x5f6f85a57d108914 => 30
	i64 6894844156784520562, ; 121: System.Numerics.Vectors => 0x5faf683aead1ad72 => 26
	i64 6968362846455497698, ; 122: Bewize.Android.dll => 0x60b49916c10283e2 => 0
	i64 7036436454368433159, ; 123: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 84
	i64 7103753931438454322, ; 124: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 81
	i64 7141281584637745974, ; 125: Xamarin.GooglePlayServices.Maps.dll => 0x631aedc3dd5f1b36 => 128
	i64 7194160955514091247, ; 126: Xamarin.Android.Support.CursorAdapter.dll => 0x63d6cb45d266f6ef => 45
	i64 7330419912715392478, ; 127: Xamarin.Forms.GoogleMaps.Android => 0x65bae21287d9d5de => 114
	i64 7488575175965059935, ; 128: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 30
	i64 7635363394907363464, ; 129: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 113
	i64 7637365915383206639, ; 130: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 112
	i64 7654504624184590948, ; 131: System.Net.Http => 0x6a3a4366801b8264 => 24
	i64 7735352534559001595, ; 132: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 132
	i64 7820441508502274321, ; 133: System.Data => 0x6c87ca1e14ff8111 => 135
	i64 7821246742157274664, ; 134: Xamarin.Android.Support.AsyncLayoutInflater => 0x6c8aa67926f72e28 => 39
	i64 7836164640616011524, ; 135: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 61
	i64 8044118961405839122, ; 136: System.ComponentModel.Composition => 0x6fa2739369944712 => 141
	i64 8083354569033831015, ; 137: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 85
	i64 8101777744205214367, ; 138: Xamarin.Android.Support.Annotations => 0x706f4beeec84729f => 38
	i64 8103644804370223335, ; 139: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 137
	i64 8167236081217502503, ; 140: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 4
	i64 8196541262927413903, ; 141: Xamarin.Android.Support.Interpolator => 0x71bff6d9fb9ec28f => 50
	i64 8385935383968044654, ; 142: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0x7460d3cd16cb566e => 36
	i64 8398329775253868912, ; 143: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 70
	i64 8400357532724379117, ; 144: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 97
	i64 8601935802264776013, ; 145: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 105
	i64 8609060182490045521, ; 146: Square.OkIO.dll => 0x7779869f8b475c51 => 18
	i64 8626175481042262068, ; 147: Java.Interop => 0x77b654e585b55834 => 4
	i64 8639588376636138208, ; 148: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 96
	i64 8684531736582871431, ; 149: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 140
	i64 8796457469147618732, ; 150: Xamarin.Android.Support.CustomTabs => 0x7a134b766a601dac => 46
	i64 8808820144457481518, ; 151: Xamarin.Android.Support.Loader.dll => 0x7a3f374010b17d2e => 51
	i64 8853378295825400934, ; 152: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 131
	i64 8917102979740339192, ; 153: Xamarin.Android.Support.DocumentFile.dll => 0x7bbfe9ea4d000bf8 => 48
	i64 9312692141327339315, ; 154: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 110
	i64 9317845861275985219, ; 155: Bewize => 0x814fa3715932e543 => 2
	i64 9324707631942237306, ; 156: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 62
	i64 9662334977499516867, ; 157: System.Numerics.dll => 0x8617827802b0cfc3 => 25
	i64 9678050649315576968, ; 158: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 72
	i64 9711637524876806384, ; 159: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 93
	i64 9808709177481450983, ; 160: Mono.Android.dll => 0x881f890734e555e7 => 7
	i64 9825649861376906464, ; 161: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 69
	i64 9834056768316610435, ; 162: System.Transactions.dll => 0x8879968718899783 => 136
	i64 9866412715007501892, ; 163: Xamarin.Android.Arch.Lifecycle.Common.dll => 0x88ec8a16fd6b6644 => 33
	i64 9875200773399460291, ; 164: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 126
	i64 9998632235833408227, ; 165: Mono.Security => 0x8ac2470b209ebae3 => 143
	i64 10038780035334861115, ; 166: System.Net.Http.dll => 0x8b50e941206af13b => 24
	i64 10229024438826829339, ; 167: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 76
	i64 10303855825347935641, ; 168: Xamarin.Android.Support.Loader => 0x8efea647eeb3fd99 => 51
	i64 10321854143672141184, ; 169: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 130
	i64 10363495123250631811, ; 170: Xamarin.Android.Support.Collections.dll => 0x8fd287e80cd8d483 => 40
	i64 10376576884623852283, ; 171: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 104
	i64 10430153318873392755, ; 172: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 74
	i64 10635644668885628703, ; 173: Xamarin.Android.Support.DrawerLayout.dll => 0x93996679ee34771f => 49
	i64 10775409704848971057, ; 174: Xamarin.Forms.Maps => 0x9589f20936d1d531 => 117
	i64 10847732767863316357, ; 175: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 63
	i64 10850923258212604222, ; 176: Xamarin.Android.Arch.Lifecycle.Runtime => 0x9696393672c9593e => 36
	i64 10913891249535884439, ; 177: Xamarin.Android.Support.CustomTabs.dll => 0x9775ee4465d49c97 => 46
	i64 11023048688141570732, ; 178: System.Core => 0x98f9bc61168392ac => 20
	i64 11037814507248023548, ; 179: System.Xml => 0x992e31d0412bf7fc => 29
	i64 11162124722117608902, ; 180: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 109
	i64 11340910727871153756, ; 181: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 75
	i64 11376461258732682436, ; 182: Xamarin.Android.Support.Compat => 0x9de14f3d5fc13cc4 => 41
	i64 11392833485892708388, ; 183: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 99
	i64 11444370155346000636, ; 184: Xamarin.Forms.Maps.Android => 0x9ed292057b7afafc => 116
	i64 11529969570048099689, ; 185: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 109
	i64 11578238080964724296, ; 186: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 84
	i64 11580057168383206117, ; 187: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 59
	i64 11597940890313164233, ; 188: netstandard => 0xa0f429ca8d1805c9 => 134
	i64 11672361001936329215, ; 189: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 81
	i64 11739066727115742305, ; 190: SQLite-net.dll => 0xa2e98afdf8575c61 => 13
	i64 11806260347154423189, ; 191: SQLite-net => 0xa3d8433bc5eb5d95 => 13
	i64 11834399401546345650, ; 192: Xamarin.Android.Support.SlidingPaneLayout.dll => 0xa43c3b8deb43ecb2 => 54
	i64 11865714326292153359, ; 193: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa4ab7c5000e8440f => 35
	i64 12013962889899020729, ; 194: Xamarin.GooglePlayServices.Auth => 0xa6ba2b987d2811b9 => 125
	i64 12102847907131387746, ; 195: System.Buffers => 0xa7f5f40c43256f62 => 19
	i64 12137774235383566651, ; 196: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 107
	i64 12279246230491828964, ; 197: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 17
	i64 12336928085371509187, ; 198: Xamarin.GooglePlayServices.Auth.Api.Phone => 0xab3592bad41bd9c3 => 123
	i64 12388767885335911387, ; 199: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0xabedbec0d236dbdb => 35
	i64 12414299427252656003, ; 200: Xamarin.Android.Support.Compat.dll => 0xac48738e28bad783 => 41
	i64 12451044538927396471, ; 201: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 80
	i64 12466513435562512481, ; 202: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 91
	i64 12487638416075308985, ; 203: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 77
	i64 12488608402635344228, ; 204: Lottie.Android => 0xad50732cba09c964 => 5
	i64 12538491095302438457, ; 205: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 67
	i64 12550732019250633519, ; 206: System.IO.Compression => 0xae2d28465e8e1b2f => 139
	i64 12700543734426720211, ; 207: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 68
	i64 12952608645614506925, ; 208: Xamarin.Android.Support.Core.Utils => 0xb3c0e8eff48193ad => 44
	i64 12963446364377008305, ; 209: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 138
	i64 13291835053457086558, ; 210: Xamarin.Forms.GoogleMaps.Android.dll => 0xb876158ed665185e => 114
	i64 13370592475155966277, ; 211: System.Runtime.Serialization => 0xb98de304062ea945 => 1
	i64 13401370062847626945, ; 212: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 107
	i64 13404347523447273790, ; 213: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 70
	i64 13454009404024712428, ; 214: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 122
	i64 13458671083851642139, ; 215: System.Json.dll => 0xbac6ce0b2dcc751b => 22
	i64 13465488254036897740, ; 216: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 132
	i64 13491513212026656886, ; 217: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 64
	i64 13572454107664307259, ; 218: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 100
	i64 13647894001087880694, ; 219: System.Data.dll => 0xbd670f48cb071df6 => 135
	i64 13828521679616088467, ; 220: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 131
	i64 13959074834287824816, ; 221: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 80
	i64 13967638549803255703, ; 222: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 118
	i64 14124974489674258913, ; 223: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 67
	i64 14172845254133543601, ; 224: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 94
	i64 14261073672896646636, ; 225: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 99
	i64 14400856865250966808, ; 226: Xamarin.Android.Support.Core.UI => 0xc7da1f051a877d18 => 43
	i64 14486659737292545672, ; 227: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 87
	i64 14644440854989303794, ; 228: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 92
	i64 14661790646341542033, ; 229: Xamarin.Android.Support.SwipeRefreshLayout => 0xcb7924e94e552091 => 55
	i64 14792063746108907174, ; 230: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 122
	i64 14852515768018889994, ; 231: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 75
	i64 14987728460634540364, ; 232: System.IO.Compression.dll => 0xcfff1ba06622494c => 139
	i64 14988210264188246988, ; 233: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 77
	i64 15188640517174936311, ; 234: Xamarin.Android.Arch.Core.Common => 0xd2c8e413d75142f7 => 31
	i64 15246441518555807158, ; 235: Xamarin.Android.Arch.Core.Common.dll => 0xd3963dc832493db6 => 31
	i64 15326820765897713587, ; 236: Xamarin.Android.Arch.Core.Runtime.dll => 0xd4b3ce481769e7b3 => 32
	i64 15370334346939861994, ; 237: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 74
	i64 15568534730848034786, ; 238: Xamarin.Android.Support.VersionedParcelable.dll => 0xd80e8bda21875fe2 => 56
	i64 15582737692548360875, ; 239: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 90
	i64 15609085926864131306, ; 240: System.dll => 0xd89e9cf3334914ea => 21
	i64 15777549416145007739, ; 241: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 102
	i64 15810740023422282496, ; 242: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 120
	i64 15930129725311349754, ; 243: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 129
	i64 16154507427712707110, ; 244: System => 0xe03056ea4e39aa26 => 21
	i64 16242842420508142678, ; 245: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe16a2b1f8908ac56 => 42
	i64 16565028646146589191, ; 246: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 141
	i64 16621146507174665210, ; 247: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 71
	i64 16677317093839702854, ; 248: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 97
	i64 16755018182064898362, ; 249: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 15
	i64 16767985610513713374, ; 250: Xamarin.Android.Arch.Core.Runtime => 0xe8b3da12798808de => 32
	i64 16822611501064131242, ; 251: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 137
	i64 16833383113903931215, ; 252: mscorlib => 0xe99c30c1484d7f4f => 8
	i64 16895806301542741427, ; 253: Plugin.Permissions => 0xea79f6503d42f5b3 => 11
	i64 16932527889823454152, ; 254: Xamarin.Android.Support.Core.Utils.dll => 0xeafc6c67465253c8 => 44
	i64 17024911836938395553, ; 255: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 60
	i64 17031351772568316411, ; 256: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 95
	i64 17037200463775726619, ; 257: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 83
	i64 17124705692820578889, ; 258: Lottie.Forms => 0xeda72d18d7ae2249 => 6
	i64 17285063141349522879, ; 259: Rg.Plugins.Popup => 0xefe0e158cc55fdbf => 12
	i64 17310799966561153083, ; 260: Xamarin.GooglePlayServices.Auth.dll => 0xf03c50da60b8b03b => 125
	i64 17383232329670771222, ; 261: Xamarin.Android.Support.CustomView.dll => 0xf13da5b41a1cc216 => 47
	i64 17428701562824544279, ; 262: Xamarin.Android.Support.Core.UI.dll => 0xf1df2fbaec73d017 => 43
	i64 17483646997724851973, ; 263: Xamarin.Android.Support.ViewPager => 0xf2a2644fe5b6ef05 => 57
	i64 17523180151706183041, ; 264: System.Json => 0xf32ed781959f6581 => 22
	i64 17524135665394030571, ; 265: Xamarin.Android.Support.Print => 0xf3323c8a739097eb => 53
	i64 17544493274320527064, ; 266: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 65
	i64 17666959971718154066, ; 267: Xamarin.Android.Support.CustomView => 0xf52da67d9f4e4752 => 47
	i64 17704177640604968747, ; 268: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 91
	i64 17710060891934109755, ; 269: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 89
	i64 17760961058993581169, ; 270: Xamarin.Android.Arch.Lifecycle.Common => 0xf67b9bfb46dbac71 => 33
	i64 17816041456001989629, ; 271: Xamarin.Forms.Maps.dll => 0xf73f4b4f90a1bbfd => 117
	i64 17838668724098252521, ; 272: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 19
	i64 17841643939744178149, ; 273: Xamarin.Android.Arch.Lifecycle.ViewModel => 0xf79a40a25573dfe5 => 37
	i64 17882897186074144999, ; 274: FormsViewGroup => 0xf82cd03e3ac830e7 => 3
	i64 17891337867145587222, ; 275: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 130
	i64 17892495832318972303, ; 276: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 120
	i64 17928294245072900555, ; 277: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 140
	i64 17958105683855786126, ; 278: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xf93801f92d25c08e => 34
	i64 17969331831154222830, ; 279: Xamarin.GooglePlayServices.Maps => 0xf95fe418471126ee => 128
	i64 17986907704309214542, ; 280: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 127
	i64 18116111925905154859, ; 281: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 64
	i64 18121036031235206392, ; 282: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 95
	i64 18129453464017766560, ; 283: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 133
	i64 18301997741680159453, ; 284: Xamarin.Android.Support.CursorAdapter => 0xfdfdc1fa58d8eadd => 45
	i64 18305135509493619199, ; 285: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 96
	i64 18370042311372477656, ; 286: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 16
	i64 18380184030268848184 ; 287: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 108
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [288 x i32] [
	i32 79, i32 7, i32 68, i32 101, i32 12, i32 115, i32 102, i32 73, ; 0..7
	i32 37, i32 88, i32 126, i32 138, i32 82, i32 40, i32 34, i32 16, ; 8..15
	i32 78, i32 136, i32 119, i32 143, i32 121, i32 0, i32 15, i32 63, ; 16..23
	i32 11, i32 1, i32 56, i32 17, i32 61, i32 90, i32 83, i32 9, ; 24..31
	i32 23, i32 62, i32 101, i32 59, i32 89, i32 9, i32 94, i32 66, ; 32..39
	i32 78, i32 142, i32 86, i32 27, i32 72, i32 106, i32 28, i32 5, ; 40..47
	i32 58, i32 29, i32 8, i32 98, i32 27, i32 54, i32 124, i32 113, ; 48..55
	i32 49, i32 121, i32 18, i32 6, i32 85, i32 60, i32 26, i32 127, ; 56..63
	i32 123, i32 10, i32 104, i32 2, i32 103, i32 25, i32 28, i32 134, ; 64..71
	i32 100, i32 79, i32 115, i32 23, i32 10, i32 73, i32 129, i32 57, ; 72..79
	i32 14, i32 48, i32 39, i32 111, i32 133, i32 108, i32 65, i32 58, ; 80..87
	i32 111, i32 103, i32 42, i32 52, i32 118, i32 53, i32 112, i32 92, ; 88..95
	i32 116, i32 124, i32 50, i32 93, i32 106, i32 105, i32 71, i32 20, ; 96..103
	i32 110, i32 69, i32 38, i32 98, i32 87, i32 55, i32 119, i32 3, ; 104..111
	i32 14, i32 52, i32 88, i32 86, i32 66, i32 76, i32 142, i32 82, ; 112..119
	i32 30, i32 26, i32 0, i32 84, i32 81, i32 128, i32 45, i32 114, ; 120..127
	i32 30, i32 113, i32 112, i32 24, i32 132, i32 135, i32 39, i32 61, ; 128..135
	i32 141, i32 85, i32 38, i32 137, i32 4, i32 50, i32 36, i32 70, ; 136..143
	i32 97, i32 105, i32 18, i32 4, i32 96, i32 140, i32 46, i32 51, ; 144..151
	i32 131, i32 48, i32 110, i32 2, i32 62, i32 25, i32 72, i32 93, ; 152..159
	i32 7, i32 69, i32 136, i32 33, i32 126, i32 143, i32 24, i32 76, ; 160..167
	i32 51, i32 130, i32 40, i32 104, i32 74, i32 49, i32 117, i32 63, ; 168..175
	i32 36, i32 46, i32 20, i32 29, i32 109, i32 75, i32 41, i32 99, ; 176..183
	i32 116, i32 109, i32 84, i32 59, i32 134, i32 81, i32 13, i32 13, ; 184..191
	i32 54, i32 35, i32 125, i32 19, i32 107, i32 17, i32 123, i32 35, ; 192..199
	i32 41, i32 80, i32 91, i32 77, i32 5, i32 67, i32 139, i32 68, ; 200..207
	i32 44, i32 138, i32 114, i32 1, i32 107, i32 70, i32 122, i32 22, ; 208..215
	i32 132, i32 64, i32 100, i32 135, i32 131, i32 80, i32 118, i32 67, ; 216..223
	i32 94, i32 99, i32 43, i32 87, i32 92, i32 55, i32 122, i32 75, ; 224..231
	i32 139, i32 77, i32 31, i32 31, i32 32, i32 74, i32 56, i32 90, ; 232..239
	i32 21, i32 102, i32 120, i32 129, i32 21, i32 42, i32 141, i32 71, ; 240..247
	i32 97, i32 15, i32 32, i32 137, i32 8, i32 11, i32 44, i32 60, ; 248..255
	i32 95, i32 83, i32 6, i32 12, i32 125, i32 47, i32 43, i32 57, ; 256..263
	i32 22, i32 53, i32 65, i32 47, i32 91, i32 89, i32 33, i32 117, ; 264..271
	i32 19, i32 37, i32 3, i32 130, i32 120, i32 140, i32 34, i32 128, ; 272..279
	i32 127, i32 64, i32 95, i32 133, i32 45, i32 96, i32 16, i32 108 ; 288..287
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
