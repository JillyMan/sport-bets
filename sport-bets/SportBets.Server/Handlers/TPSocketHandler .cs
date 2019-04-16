﻿using SportBets.Core.Serializer;
using SportBets.Server.Core.Contracts.Serializer;
using SportBets.Server.Core.Networking;
using SportBets.Server.Core.Handlers;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SportBets.Server.Core.Handlers
{
	public class TPSocketHandler : ISocketHandler
	{
		private IRequestHandler _requestHandler;
		private ISerializer _serializer;

		public TPSocketHandler(IRequestHandler requestHandler, ISerializer serializer)
		{
			_serializer = serializer;
			_requestHandler = requestHandler;
		}

		public async Task Process(Socket socket)
		{
			//TODO: dependency -> json fix.
			await Task.Run(async () =>
			{
				var tp = new TransferProtocolServer(socket, _serializer);
				var request = tp.Receive<TPRequest>();
				await _requestHandler.Handle(request, tp);
			});
		}
	}
}