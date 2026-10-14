# Cube-

Run

nasm -f elf64 rot.asm -o rot.o
gcc -shared -o librot.so rot.o
dotnet new console -n Cube && cd Cube   replace Program.cs   
add <AllowUnsafeBlocks>true</AllowUnsafeBlocks> to the .csproj
cp ../librot.so .
dotnet run
