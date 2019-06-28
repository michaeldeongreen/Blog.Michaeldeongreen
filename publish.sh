"c:/Git/Blog.Michaeldeongreen\gc-cli.sh" build -prod

rm -rf "c:/temp/My Blog Uploads/dist/api" && mkdir "c:/temp/My Blog Uploads/dist/api"
dotnet publish "C:\Git\Blog.Michaeldeongreen\WebApi\Blog.Michaeldeongreen.Core.Web.Api" -c Release -o "C:\temp\My Blog Uploads\dist\api"

cd c:/Git/Blog.Michaeldeongreen/WebClient
ng build --prod --output-path "C:\temp\My Blog Uploads\dist\client"

exit 0