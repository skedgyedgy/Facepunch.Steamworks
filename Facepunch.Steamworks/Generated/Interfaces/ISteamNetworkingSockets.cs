using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	internal class ISteamNetworkingSockets : SteamInterface
	{
		public override IntPtr GetInterfacePointer() => GetApi.SteamNetworkingSockets();
		
		
		internal ISteamNetworkingSockets()
		{
			SetupInterface();
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateListenSocketIP")]
		private static extern Socket _CreateListenSocketIP( IntPtr self, ref NetAddress localAddress, int nOptions, ref NetConfig_t pOptions );
		
		#endregion
		internal Socket CreateListenSocketIP( ref NetAddress localAddress, int nOptions, ref NetConfig_t pOptions )
		{
			var returnValue = _CreateListenSocketIP( Self, ref localAddress, nOptions, ref pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectByIPAddress")]
		private static extern Connection _ConnectByIPAddress( IntPtr self, ref NetAddress address, int nOptions, ref NetConfig_t pOptions );
		
		#endregion
		internal Connection ConnectByIPAddress( ref NetAddress address, int nOptions, ref NetConfig_t pOptions )
		{
			var returnValue = _ConnectByIPAddress( Self, ref address, nOptions, ref pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateListenSocketP2P")]
		private static extern Socket _CreateListenSocketP2P( IntPtr self, int nVirtualPort, int nOptions, ref NetConfig_t pOptions );
		
		#endregion
		internal Socket CreateListenSocketP2P( int nVirtualPort, int nOptions, ref NetConfig_t pOptions )
		{
			var returnValue = _CreateListenSocketP2P( Self, nVirtualPort, nOptions, ref pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectP2P")]
		private static extern Connection _ConnectP2P( IntPtr self, ref NetIdentity identityRemote, int nVirtualPort, int nOptions, ref NetConfig_t pOptions );
		
		#endregion
		internal Connection ConnectP2P( ref NetIdentity identityRemote, int nVirtualPort, int nOptions, ref NetConfig_t pOptions )
		{
			var returnValue = _ConnectP2P( Self, ref identityRemote, nVirtualPort, nOptions, ref pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_AcceptConnection")]
		private static extern Result _AcceptConnection( IntPtr self, Connection hConn );
		
		#endregion
		internal Result AcceptConnection( Connection hConn )
		{
			var returnValue = _AcceptConnection( Self, hConn );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CloseConnection")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _CloseConnection( IntPtr self, Connection hPeer, int nReason, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszDebug, [MarshalAs( UnmanagedType.U1 )] bool bEnableLinger );
		
		#endregion
		internal bool CloseConnection( Connection hPeer, int nReason, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszDebug, [MarshalAs( UnmanagedType.U1 )] bool bEnableLinger )
		{
			var returnValue = _CloseConnection( Self, hPeer, nReason, pszDebug, bEnableLinger );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CloseListenSocket")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _CloseListenSocket( IntPtr self, Socket hSocket );
		
		#endregion
		internal bool CloseListenSocket( Socket hSocket )
		{
			var returnValue = _CloseListenSocket( Self, hSocket );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionUserData")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _SetConnectionUserData( IntPtr self, Connection hPeer, long nUserData );
		
		#endregion
		internal bool SetConnectionUserData( Connection hPeer, long nUserData )
		{
			var returnValue = _SetConnectionUserData( Self, hPeer, nUserData );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionUserData")]
		private static extern long _GetConnectionUserData( IntPtr self, Connection hPeer );
		
		#endregion
		internal long GetConnectionUserData( Connection hPeer )
		{
			var returnValue = _GetConnectionUserData( Self, hPeer );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionName")]
		private static extern void _SetConnectionName( IntPtr self, Connection hPeer, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszName );
		
		#endregion
		internal void SetConnectionName( Connection hPeer, [MarshalAs( UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof( Utf8StringToNative ) )] string pszName )
		{
			_SetConnectionName( Self, hPeer, pszName );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionName")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _GetConnectionName( IntPtr self, Connection hPeer, IntPtr pszName, int nMaxLen );
		
		#endregion
		internal bool GetConnectionName( Connection hPeer, out string pszName )
		{
			IntPtr mempszName = Helpers.TakeMemory();
			var returnValue = _GetConnectionName( Self, hPeer, mempszName, (1024 * 32) );
			pszName = Helpers.MemoryToString( mempszName );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SendMessageToConnection")]
		private static extern Result _SendMessageToConnection( IntPtr self, Connection hConn, IntPtr pData, uint cbData, int nSendFlags, [In,Out] long[]  pOutMessageNumber );
		
		#endregion
		internal Result SendMessageToConnection( Connection hConn, IntPtr pData, uint cbData, int nSendFlags, [In,Out] long[]  pOutMessageNumber )
		{
			var returnValue = _SendMessageToConnection( Self, hConn, pData, cbData, nSendFlags, pOutMessageNumber );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SendMessages")]
		private static extern void _SendMessages( IntPtr self, int nMessages, ref NetMsg pMessages, [In,Out] long[]  pOutMessageNumberOrResult );
		
		#endregion
		internal void SendMessages( int nMessages, ref NetMsg pMessages, [In,Out] long[]  pOutMessageNumberOrResult )
		{
			_SendMessages( Self, nMessages, ref pMessages, pOutMessageNumberOrResult );
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_FlushMessagesOnConnection")]
		private static extern Result _FlushMessagesOnConnection( IntPtr self, Connection hConn );
		
		#endregion
		internal Result FlushMessagesOnConnection( Connection hConn )
		{
			var returnValue = _FlushMessagesOnConnection( Self, hConn );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnConnection")]
		private static extern int _ReceiveMessagesOnConnection( IntPtr self, Connection hConn, IntPtr ppOutMessages, int nMaxMessages );
		
		#endregion
		internal int ReceiveMessagesOnConnection( Connection hConn, IntPtr ppOutMessages, int nMaxMessages )
		{
			var returnValue = _ReceiveMessagesOnConnection( Self, hConn, ppOutMessages, nMaxMessages );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetConnectionInfo")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _GetConnectionInfo( IntPtr self, Connection hConn, ref ConnectionInfo pInfo );
		
		#endregion
		internal bool GetConnectionInfo( Connection hConn, ref ConnectionInfo pInfo )
		{
			var returnValue = _GetConnectionInfo( Self, hConn, ref pInfo );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetQuickConnectionStatus")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _GetQuickConnectionStatus( IntPtr self, Connection hConn, ref SteamNetworkingQuickConnectionStatus pStats );
		
		#endregion
		internal bool GetQuickConnectionStatus( Connection hConn, ref SteamNetworkingQuickConnectionStatus pStats )
		{
			var returnValue = _GetQuickConnectionStatus( Self, hConn, ref pStats );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetDetailedConnectionStatus")]
		private static extern int _GetDetailedConnectionStatus( IntPtr self, Connection hConn, IntPtr pszBuf, int cbBuf );
		
		#endregion
		internal int GetDetailedConnectionStatus( Connection hConn, out string pszBuf )
		{
			IntPtr mempszBuf = Helpers.TakeMemory();
			var returnValue = _GetDetailedConnectionStatus( Self, hConn, mempszBuf, (1024 * 32) );
			pszBuf = Helpers.MemoryToString( mempszBuf );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetListenSocketAddress")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _GetListenSocketAddress( IntPtr self, Socket hSocket, ref NetAddress address );
		
		#endregion
		internal bool GetListenSocketAddress( Socket hSocket, ref NetAddress address )
		{
			var returnValue = _GetListenSocketAddress( Self, hSocket, ref address );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateSocketPair")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _CreateSocketPair( IntPtr self, [In,Out] Connection[]  pOutConnection1, [In,Out] Connection[]  pOutConnection2, [MarshalAs( UnmanagedType.U1 )] bool bUseNetworkLoopback, ref NetIdentity pIdentity1, ref NetIdentity pIdentity2 );
		
		#endregion
		internal bool CreateSocketPair( [In,Out] Connection[]  pOutConnection1, [In,Out] Connection[]  pOutConnection2, [MarshalAs( UnmanagedType.U1 )] bool bUseNetworkLoopback, ref NetIdentity pIdentity1, ref NetIdentity pIdentity2 )
		{
			var returnValue = _CreateSocketPair( Self, pOutConnection1, pOutConnection2, bUseNetworkLoopback, ref pIdentity1, ref pIdentity2 );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetIdentity")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _GetIdentity( IntPtr self, ref NetIdentity pIdentity );
		
		#endregion
		internal bool GetIdentity( ref NetIdentity pIdentity )
		{
			var returnValue = _GetIdentity( Self, ref pIdentity );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_InitAuthentication")]
		private static extern SteamNetworkingAvailability _InitAuthentication( IntPtr self );
		
		#endregion
		internal SteamNetworkingAvailability InitAuthentication()
		{
			var returnValue = _InitAuthentication( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetAuthenticationStatus")]
		private static extern SteamNetworkingAvailability _GetAuthenticationStatus( IntPtr self, ref SteamNetAuthenticationStatus_t pDetails );
		
		#endregion
		internal SteamNetworkingAvailability GetAuthenticationStatus( ref SteamNetAuthenticationStatus_t pDetails )
		{
			var returnValue = _GetAuthenticationStatus( Self, ref pDetails );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreatePollGroup")]
		private static extern HSteamNetPollGroup _CreatePollGroup( IntPtr self );
		
		#endregion
		internal HSteamNetPollGroup CreatePollGroup()
		{
			var returnValue = _CreatePollGroup( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_DestroyPollGroup")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _DestroyPollGroup( IntPtr self, HSteamNetPollGroup hPollGroup );
		
		#endregion
		internal bool DestroyPollGroup( HSteamNetPollGroup hPollGroup )
		{
			var returnValue = _DestroyPollGroup( Self, hPollGroup );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetConnectionPollGroup")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _SetConnectionPollGroup( IntPtr self, Connection hConn, HSteamNetPollGroup hPollGroup );
		
		#endregion
		internal bool SetConnectionPollGroup( Connection hConn, HSteamNetPollGroup hPollGroup )
		{
			var returnValue = _SetConnectionPollGroup( Self, hConn, hPollGroup );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceiveMessagesOnPollGroup")]
		private static extern int _ReceiveMessagesOnPollGroup( IntPtr self, HSteamNetPollGroup hPollGroup, IntPtr ppOutMessages, int nMaxMessages );
		
		#endregion
		internal int ReceiveMessagesOnPollGroup( HSteamNetPollGroup hPollGroup, IntPtr ppOutMessages, int nMaxMessages )
		{
			var returnValue = _ReceiveMessagesOnPollGroup( Self, hPollGroup, ppOutMessages, nMaxMessages );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceivedRelayAuthTicket")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _ReceivedRelayAuthTicket( IntPtr self, IntPtr pvTicket, int cbTicket, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket );
		
		#endregion
		internal bool ReceivedRelayAuthTicket( IntPtr pvTicket, int cbTicket, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket )
		{
			var returnValue = _ReceivedRelayAuthTicket( Self, pvTicket, cbTicket, pOutParsedTicket );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_FindRelayAuthTicketForServer")]
		private static extern int _FindRelayAuthTicketForServer( IntPtr self, ref NetIdentity identityGameServer, int nVirtualPort, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket );
		
		#endregion
		internal int FindRelayAuthTicketForServer( ref NetIdentity identityGameServer, int nVirtualPort, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket )
		{
			var returnValue = _FindRelayAuthTicketForServer( Self, ref identityGameServer, nVirtualPort, pOutParsedTicket );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectToHostedDedicatedServer")]
		private static extern Connection _ConnectToHostedDedicatedServer( IntPtr self, ref NetIdentity identityTarget, int nVirtualPort, int nOptions, ref NetConfig_t pOptions );
		
		#endregion
		internal Connection ConnectToHostedDedicatedServer( ref NetIdentity identityTarget, int nVirtualPort, int nOptions, ref NetConfig_t pOptions )
		{
			var returnValue = _ConnectToHostedDedicatedServer( Self, ref identityTarget, nVirtualPort, nOptions, ref pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPort")]
		private static extern ushort _GetHostedDedicatedServerPort( IntPtr self );
		
		#endregion
		internal ushort GetHostedDedicatedServerPort()
		{
			var returnValue = _GetHostedDedicatedServerPort( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerPOPID")]
		private static extern SteamNetworkingPOPID _GetHostedDedicatedServerPOPID( IntPtr self );
		
		#endregion
		internal SteamNetworkingPOPID GetHostedDedicatedServerPOPID()
		{
			var returnValue = _GetHostedDedicatedServerPOPID( Self );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetHostedDedicatedServerAddress")]
		private static extern Result _GetHostedDedicatedServerAddress( IntPtr self, ref SteamDatagramHostedAddress pRouting );
		
		#endregion
		internal Result GetHostedDedicatedServerAddress( ref SteamDatagramHostedAddress pRouting )
		{
			var returnValue = _GetHostedDedicatedServerAddress( Self, ref pRouting );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_CreateHostedDedicatedServerListenSocket")]
		private static extern Socket _CreateHostedDedicatedServerListenSocket( IntPtr self, int nVirtualPort, int nOptions, ref NetConfig_t pOptions );
		
		#endregion
		internal Socket CreateHostedDedicatedServerListenSocket( int nVirtualPort, int nOptions, ref NetConfig_t pOptions )
		{
			var returnValue = _CreateHostedDedicatedServerListenSocket( Self, nVirtualPort, nOptions, ref pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetGameCoordinatorServerLogin")]
		private static extern Result _GetGameCoordinatorServerLogin( IntPtr self, ref SteamDatagramGameCoordinatorServerLogin pLoginInfo, ref int pcbSignedBlob, IntPtr pBlob );
		
		#endregion
		internal Result GetGameCoordinatorServerLogin( ref SteamDatagramGameCoordinatorServerLogin pLoginInfo, ref int pcbSignedBlob, IntPtr pBlob )
		{
			var returnValue = _GetGameCoordinatorServerLogin( Self, ref pLoginInfo, ref pcbSignedBlob, pBlob );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ConnectP2PCustomSignaling")]
		private static extern Connection _ConnectP2PCustomSignaling( IntPtr self, IntPtr pSignaling, ref NetIdentity pPeerIdentity, int nOptions, ref NetConfig_t pOptions );
		
		#endregion
		internal Connection ConnectP2PCustomSignaling( IntPtr pSignaling, ref NetIdentity pPeerIdentity, int nOptions, ref NetConfig_t pOptions )
		{
			var returnValue = _ConnectP2PCustomSignaling( Self, pSignaling, ref pPeerIdentity, nOptions, ref pOptions );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_ReceivedP2PCustomSignal")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _ReceivedP2PCustomSignal( IntPtr self, IntPtr pMsg, int cbMsg, IntPtr pContext );
		
		#endregion
		internal bool ReceivedP2PCustomSignal( IntPtr pMsg, int cbMsg, IntPtr pContext )
		{
			var returnValue = _ReceivedP2PCustomSignal( Self, pMsg, cbMsg, pContext );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_GetCertificateRequest")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _GetCertificateRequest( IntPtr self, ref int pcbBlob, IntPtr pBlob, ref SteamNetworkingErrMsg errMsg );
		
		#endregion
		internal bool GetCertificateRequest( ref int pcbBlob, IntPtr pBlob, ref SteamNetworkingErrMsg errMsg )
		{
			var returnValue = _GetCertificateRequest( Self, ref pcbBlob, pBlob, ref errMsg );
			return returnValue;
		}
		
		#region FunctionMeta
		[DllImport( Platform.LibraryName, EntryPoint = "SteamAPI_ISteamNetworkingSockets_SetCertificate")]
		[return: MarshalAs( UnmanagedType.I1 )]
		private static extern bool _SetCertificate( IntPtr self, IntPtr pCertificate, int cbCertificate, ref SteamNetworkingErrMsg errMsg );
		
		#endregion
		internal bool SetCertificate( IntPtr pCertificate, int cbCertificate, ref SteamNetworkingErrMsg errMsg )
		{
			var returnValue = _SetCertificate( Self, pCertificate, cbCertificate, ref errMsg );
			return returnValue;
		}
		
	}
}
