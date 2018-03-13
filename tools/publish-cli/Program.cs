using System;
using System.Linq;
using System.Threading.Tasks;
using Colors.Net;
using Colors.Net.StringColorExtensions;

namespace PublishCli
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => AsyncMain(args)).Wait();
        }

        static async Task AsyncMain(string[] args)
        {
            var version = args.FirstOrDefault();
            if (!version.StartsWith("2"))
            {
                ColoredConsole.Error.WriteLine("This tool can only be used to publish 2.x CLI releases".Red());
                return;
            }
            await ArmHelpers.CheckAccess();
            // Check jit access
            // Download build
            // Smoke test
            // update storage
            // update npm
            // update homebrew
            // update debian
            // update rpm
        }
    }
}
