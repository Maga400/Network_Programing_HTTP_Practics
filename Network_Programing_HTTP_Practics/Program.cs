//Server Side
using System.ComponentModel.DataAnnotations;
using System.Net;

Console.WriteLine("Hello, World!");

using HttpListener listener = new HttpListener();

listener.Prefixes.Add("http://127.0.0.1:27001/");
listener.Prefixes.Add("http://127.0.0.1:27002/");
listener.Prefixes.Add("http://127.0.0.1:27003/");
listener.Prefixes.Add("http://localhost:27001/");

listener.Start();

while (true)
{
    var context = listener.GetContext();

    _ = Task.Run(() =>
    {
        HttpListenerRequest? request = context.Request;

        HttpListenerResponse? response = context.Response;
        response.ContentType = "text/html";
        response.Headers.Add("Content-Type", "text/html");
        response.Headers.Add("Server", "Step");
        response.Headers.Add("Date", DateTime.Now.ToString());

        var url = request.RawUrl;
        Console.WriteLine(url);
        var urls = url?.Split('/').ToList();
        if (url == "/")
        {
            response.StatusCode = 200;

            using var writer = new StreamWriter(response.OutputStream);

            var index = File.ReadAllText("index.html");
            writer.Write(index);
        }
        else if (urls[1] == "index" || urls[1] == "index.html")
        {
            response.StatusCode = 200;

            using var writer = new StreamWriter(response.OutputStream);

            var index = File.ReadAllText("index.html");
            writer.Write(index);
        }

        else if (urls[1] == "about" || urls[1] == "about.html")
        {
            response.StatusCode = 200;

            using var writer = new StreamWriter(response.OutputStream);

            var index = File.ReadAllText("about.html");
            writer.Write(index);
        }
        else if (urls[1] == "contact" || urls[1] == "contact.html")
        {
            response.StatusCode = 200;


            // Data Content
            using var writer = new StreamWriter(response.OutputStream);

            var index = File.ReadAllText("contact.html");
            writer.Write(index);
        }
        else if (urls[1] == "gallery" || urls[1] == "gallery.html")
        {
            response.StatusCode = 200;


            // Data Content
            using var writer = new StreamWriter(response.OutputStream);

            var index = File.ReadAllText("gallery.html");
            writer.Write(index);
        }
        else
        {
            response.StatusCode = 404;
            // Data Content
            using var writer = new StreamWriter(response.OutputStream);

            var index = File.ReadAllText("404.html");
            writer.Write(index);
        }

    });

}