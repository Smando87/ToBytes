# ByteSerializer

ByteSerializer is a C# library for serializing various types of objects into byte arrays. It supports handling different data types such as arrays, dictionaries, lists, structs, enums, and strings. The library includes features for encryption and writing serialized data to files.

## Features

- Serialize and deserialize objects to and from byte arrays.
- Support for arrays, dictionaries, lists, structs, enums, and strings.
- Encryption of serialized data.
- Caching of converters and methods for optimized performance.
- Writing serialized data to files.

## Installation

To include ByteSerializer in your project, add the following line to your `.csproj` file:

```xml
<PackageReference Include="ToBytes" Version="1.0.0" />
```

Or install via NuGet Package Manager:

```sh
Install-Package ToBytes
```

## Usage

### Serialize and Deserialize an Object to a Byte Array

```csharp
using ToBytes;

var myObject = new MyClass();
byte[] serializedData = myObject.ToBytes(myObject);

var deserializedObject =serializedData.FromBytes<MyClass>()
```

### Write Serialized Data to a File

```csharp
using ToBytes;

var myObject = new MyClass();
ByteSerializer.WriteToFile(myObject, "path/to/file");
```

### Encrypt and Write Serialized Data to a File

```csharp
using ToBytes;

var myObject = new MyClass();
string password = "securePassword";
ByteSerializer.WriteEncryptedToFile(myObject, "path/to/file", password);
```

## Custom Serialization

ByteSerializer supports custom struct converters for specific serialization requirements. Implement the `IStructConverter` interface to create custom converters.

```csharp
public class CustomStructConverter : IStructConverter
{
    public byte[] ToBytes(object obj)
    {
        // Implement custom serialization logic
    }

    public int Type => (int)ValueType.CustomStruct;
}
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or suggestions, feel free to reach out via [GitHub Issues]([https://github.com/your-repo/byte-serializer/issues](https://github.com/Smando87/ToBytes/issues)).
```

