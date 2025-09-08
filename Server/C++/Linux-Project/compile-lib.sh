g++ -c ../src/coms.cpp -o cPostLib.o
gcc -shared -o ../bin/cPostLib.so cPostLib.o

rm cPostLib.o
# only copies if dotnet run is ran first :)
# Update the .NET Framework version in the Server.csproj file if you change this path
cp ../bin/cPostLib.so ../../bin/Debug/net9.0

# docker
#cd ../
#dotnet publish -c Release -o ./out --no-restore
#cd C++
#mv cPostLib.so ../bin/Publish/net6.0