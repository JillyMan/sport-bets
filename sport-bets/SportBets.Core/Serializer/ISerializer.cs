﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SportBets.Core.Serializer
{

	public interface ISerializer
	{
 		string Serialize<TInput>(TInput input);
		TOutput Deserialize<TOutput>(string data);
	}

}
