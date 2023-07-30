

<!-- ABOUT THE PROJECT -->
## About The Project

The library allows you to convert any object or class into a byte array and vice versa.

### Installation

Install the package from NUGET and start using it
   ```powershell
   dotnet add package ToBytes
   ```
### Usage
```c#
var obj = new DummyObject();
obj.Name = "Test";
obj.Id= 123;

var bytes[] = obj.ToBytes();

var deserializedObj = bytes.FromBytes<DummyObject>();

Console.WriteLine(deserializedObj.Name); // output: Test

   ```
