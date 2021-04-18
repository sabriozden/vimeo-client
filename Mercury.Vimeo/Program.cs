using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VimeoDotNet.Models;
using VimeoDotNet.Net;
using VimeoDotNet.Parameters;

namespace Mercury.Vimeo
{
    class Program
    {
        static async Task Main(string[] args)
        {




            var userAuthenticatedClient = new VimeoDotNet.VimeoClient("Token buraya eklenir");

            await MoveToVideoFolder(userAuthenticatedClient);

            await CreateVideoFolder(userAuthenticatedClient);

            await GetAlbumsAsync(userAuthenticatedClient);

            await CreateAlbum(userAuthenticatedClient);

            //Upload yetki olmadığından yapılamıyor
            await Upload(userAuthenticatedClient);

            await AddToAlbumAsync(userAuthenticatedClient);
            await GetAlbumsAsync(userAuthenticatedClient);

        }

        public static async Task MoveToVideoFolder(VimeoDotNet.VimeoClient userAuthenticatedClient)
        {
            await userAuthenticatedClient.MoveVideoToFolder(4187546, 538100001);
        }

        private static async Task CreateVideoFolder(VimeoDotNet.VimeoClient userAuthenticatedClient)
        {
            await userAuthenticatedClient.CreateVideoFolder(UserId.Me, "Test123");
        }

        public static async Task CreateAlbum(VimeoDotNet.VimeoClient userAuthenticatedClient)
        {
            var result = await userAuthenticatedClient.CreateAlbumAsync(UserId.Me, new VimeoDotNet.Parameters.EditAlbumParameters
            {

                Description = "Test",
                Name = "Test",

                Privacy = VimeoDotNet.Parameters.EditAlbumPrivacyOption.Anybody,

            });
        }
        //video
        //my = 538100001



        public static async Task Upload(VimeoDotNet.VimeoClient userAuthenticatedClient)
        {

            var result = await userAuthenticatedClient.UploadEntireFileAsync(new BinaryContent(@"C:\Users\pc\Downloads\Test.mp4"));
        }


        public static async Task AddToAlbumAsync(VimeoDotNet.VimeoClient userAuthenticatedClient)
        {


            var result = await userAuthenticatedClient.AddToAlbumAsync(UserId.Me, 8372608, 535964694);
        }


        public static async Task GetAlbumsAsync(VimeoDotNet.VimeoClient userAuthenticatedClient)
        {


            var result = await userAuthenticatedClient.GetAlbumsAsync(UserId.Me, new GetAlbumsParameters
            {
                Direction = GetAlbumsSortDirectionOption.Asc,
                PerPage = 10,
                Page = 1
            });
        }


    }
}
