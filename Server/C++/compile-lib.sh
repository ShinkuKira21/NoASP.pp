g++ -c coms.cpp -o cPostLib.o
gcc -shared -o cPostLib.so cPostLib.o

rm cPostLib.o
cp cPostLib.so ../bin/Debug/net6.0

# docker
#cd ../
#dotnet publish -c Release -o ./out --no-restore
#cd C++
#mv cPostLib.so ../bin/Publish/net6.0