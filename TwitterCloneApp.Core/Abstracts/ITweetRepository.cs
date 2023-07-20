using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterCloneApp.Core.Models;

namespace TwitterCloneApp.Core.Abstracts
{
	public interface ITweetRepository : IGenericRepository<Tweet>
	{
		Task<List<Tweet>> GetTweets();
	}
}
