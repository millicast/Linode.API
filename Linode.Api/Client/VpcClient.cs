using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linode.Api.Objets.Vpc;

namespace Linode.Api.Client
{
    public class VpcClient
    {
        private readonly string _token;

        public VpcClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Display all VPCs on your account
        /// </summary>
        /// <returns></returns>
        public async Task<List<Vpc>> Get()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get information about a single VPC
        /// </summary>
        /// <param name="id">The id of the VPC</param>
        /// <returns></returns>
        public async Task<Vpc> Get(long id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<Vpc> Create(string region, string label, string description = null, List<(string Ipv4, string Label)> subnets = null)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<Vpc> Update(Vpc vpc)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task Delete(long id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task Delete(Vpc vpc)
        {
            await Delete(vpc.Id);
        }
    }
}