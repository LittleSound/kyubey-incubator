using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Andoromeda.Kyubey.Incubator.Hubs
{
    public class SimpleWalletHub : Hub
    {
        public async Task BindUUID(Guid id)
        {
            var _id = id.ToString().ToLower();
            await Groups.AddToGroupAsync(Context.ConnectionId, _id);
        }
    }
}
