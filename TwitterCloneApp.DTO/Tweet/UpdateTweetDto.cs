﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterCloneApp.DTO.Tweet
{
	public class UpdateTweetDto
	{
		public int UserId { get; set; }
		public string? Content { get; set; }
	}
}
