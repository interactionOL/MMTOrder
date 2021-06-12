# README #

1. I have made the assumption that this is the fist step in a larger project. For smaller, test scenarios, the number of project would be reduced, possibly just in a single project.
2. There wasn't really sufficient time to get significant testing done, but there are unit tests covering the main points
3. Postman script is included for testing. (I just used the same one with changing the parameters)
4. It was a bit longer than 4 hours, but for personal reasons, it was a useful and helpful exercise.

# Improvements #
1. The unit tests only cover the more complex items (such as the logic in the mapper profile for the Gift requirement), more time would allow more testing of all profiles, and services.
2. I have included the AddEnvironmentVariables command, and the intent is to store the API key and DB connection in there, rather than in the config app.settings files. 
However, the development system woudl assume would use a development key, but if that was not the case, then an environment variable can be used in dev as well.
3. For testing, I just used settings in appsettings. Assumed the development settings were not secure. For live, this would go into either environment variables or using secrets