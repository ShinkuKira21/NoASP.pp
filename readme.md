**Template Details**

The ViteJS project offers a scaffolding of the Vite JavaScript and ASP.NET backend. 

Step 1: Click `Use Template' to use ViteJS and ASP.NET.

**Note:** The aim of this template is toward intermediate to experienced web developers. Testing of the brief instructions works on Debian and Ubuntu. However, feel free to experiment. You will need to look into installing Docker or NPM and DotNet for your operating system to run the following commands.

**Docker Project**

Step 1: Run ```sudo docker-compose build``` to build the project with Docker.

Step 2: Run ```sudo docker-compose up``` to run the frontend and backend.

**NPM, CPP and DOTNET CLI**

Step NPM 1: ```cd Client```.

Step NPM 2: ```npm install```.

Step NPM 3: ```npm run dev``` *(take a look into the package.json to see the other default runtimes the package is setup.)*

Step C++ 1: ```cd ../Linux-Project```

Step C++ 2: ```sh compile-lib.sh```

Step DN 1: ```cd ../../Server```.

Step DN 2: ```dotnet run```.

** (Windows) VS Studio **

Step NPM 1: ```cd Client```.

Step NPM 2: ```npm install```.

Step NPM 3: ```npm run dev``` *(take a look into the package.json to see the other default runtimes the package is setup.)*

Step C++ 1: Navigate to ```Server/C++/Windows-Project```

Step C++ 2: Open Windows-Project.sln with Visual Studio. 

Step C++ 3: Select Release/Debug Configuration.

Step C++ 4: CTRL + Shift + B (Build All) (Solution will copy the library files to the ASP.NET Project)

Step DN 1: Navigate to ```Server\``` and open Server.csproj (with Visual Studio)

Step DN 2: CTRL + F5 (Run without Debugging) and open ```https://localhost:3000/swagger/index.html``` to test WebAPI EndPoints