using Nancy;

namespace netcoretalk.Features.Home
{
    public class HomeModule : NancyModule
    {
        private readonly NameGenerator nameGenerator;

        public HomeModule(NameGenerator nameGenerator)
        {
            this.nameGenerator = nameGenerator;

            Get("/", args => GetHome(args));
        }

        private dynamic GetHome(dynamic args)
        {
            return this.nameGenerator.GetName();
        }
    }
}