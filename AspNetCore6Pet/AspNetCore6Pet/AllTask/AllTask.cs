namespace AspNetCore6Pet.AllTask
{
    public class AllTask
    {
        InitialData initialData = new InitialData();

        public async Task MainTask(HttpContext context)
        {
            var response = context.Response;
            var request = context.Request;
            var path = request.Path;

            string expressionForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";

            if (path == "/api/users" && request.Method == "GET")
            {
                await GetAllPerson(response);
            }

            else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
            {
                string? id = path.Value?.Split("/")[3];
                await GetPerson(id, response);
            }

            else if (path == "/api/users" && request?.Method == "POST")
            {
                await CreatePerson(response, request);
            }

            else if (path == "/api/users" && request?.Method == "PUT")
            {
                await UpdatePerson(response, request);
            }

            else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
            {
                string? id = path.Value?.Split("/")[3];
                await DeletePerson(id, response);
            }

            else
            {
                response.ContentType = "text/html; charset=utf-8";
                await response.SendFileAsync("html/index.html");
            }
        }

        async Task GetAllPerson(HttpResponse response)
        {
            await response.WriteAsJsonAsync(initialData.users);
        }

        async Task GetPerson(string? id, HttpResponse response)
        {
            Person? user = initialData.users.FirstOrDefault(x => x.Id == id);

            if (user != null)
                await response.WriteAsJsonAsync(user);

            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
            }
        }

        async Task CreatePerson(HttpResponse response, HttpRequest request)
        {
            try
            {
                var user = await request.ReadFromJsonAsync<Person>();
                
                if(user != null)
                {
                    user.Id = Guid.NewGuid().ToString();

                    initialData.users.Add(user);

                    await response.WriteAsJsonAsync(user);
                }

                else
                {
                    throw new Exception("Некоректные данные");
                }
            }

            catch
            {
                response.StatusCode = 400;
                await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
            }
        }

        async Task UpdatePerson(HttpResponse response, HttpRequest request)
        {
            try
            {
               
                Person? userData = await request.ReadFromJsonAsync<Person>();
                if (userData != null)
                {
                    var user = initialData.users.FirstOrDefault(u => u.Id == userData.Id);
                    
                    if (user != null)
                    {
                        user.Age = userData.Age;

                        user.Name = userData.Name;

                        await response.WriteAsJsonAsync(user);
                    }
                    else
                    {
                        response.StatusCode = 404;

                        await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
                    }
                }
                else
                {
                    throw new Exception("Некорректные данные");
                }
            }
            catch (Exception)
            {
                response.StatusCode = 400;

                await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
            }
        }

        async Task DeletePerson(string? id, HttpResponse response)
        {
            Person? user = initialData.users.FirstOrDefault((u) => u.Id == id);

            if (user != null)
            {
                initialData.users.Remove(user);

                await response.WriteAsJsonAsync(user);
            }

            else
            {
                response.StatusCode = 404;

                await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
            }
        }
    }
}

