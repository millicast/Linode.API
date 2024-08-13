using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Linode.Api.Objets.Image;
using Linode.Api.Objets.Image.Get;

namespace Linode.Api.Client
{
    public class ImageClient
    {
        private readonly string _token;

        public ImageClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// Returns a paginated list of Images.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Image>> Get()
        {
            List<Image> list = new List<Image>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                Response response = JsonConvert.DeserializeObject<Response>(await Core.SendGetRequest(_token, $"/images/?page={page}&page_size={Core.PerPage}")) ?? new Response();

                // Run
                foreach (Image row in response.Data)
                {
                    list.Add(row);
                }

                // Finish?
                if (response.Page >= response.Pages)
                {
                    // Yes, finish
                    return list;
                }
            }
        }

        /// <summary>
        /// Get information about a single Image.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Image> Get(string id)
        {
            // Get list
            string json = await Core.SendGetRequest(_token, $"/images/{id}");

            // Set
            Image image = JsonConvert.DeserializeObject<Image>(json) ?? new Image();

            // Return
            return image;
        }

        /// <summary>
        /// Captures a private, gold-master image from a Linode disk.
        /// </summary>
        /// <param name="diskId"></param>
        /// <param name="label"></param>
        /// <param name="description"></param>
        /// <param name="cloudInit"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task<Image> Create(string diskId, string label = null, string description = null, bool cloudInit = false, List<string> tags = null)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a private image.
        /// You can't update the regions with this operation. Use the Replicate an image operation to modify the existing regions for your image.
        /// </summary>
        /// <param name="image">Image</param>
        /// <returns></returns>
        public async Task<Image> Update(Image image)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a private image
        /// </summary>
        /// <param name="id">ID of the Image</param>
        /// <returns></returns>
        public async Task Delete(string id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a private image
        /// </summary>
        /// <param name="image">Image</param>
        /// <returns></returns>
        public async Task Delete(Image image)
        {
            await Delete(image.Id);
        }

        /// <summary>
        /// Target an existing image and replicate it to another compute region
        /// </summary>
        /// <param name="id">The unique identifier assigned to the image after creation</param>
        /// <param name="regions">The unique identifier for each compute region</param>
        public async Task Replicate(string id, List<string> regions)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
