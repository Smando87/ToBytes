# ToBytes

ToBytes is a C# library for serializing various types of objects into byte arrays. It supports handling different data types such as arrays, dictionaries, lists, structs, enums, and strings. The library includes features for encryption and writing serialized data to files.

## Features

- **Serialize and Deserialize Objects:** Convert objects to byte arrays and vice versa.
- **Encryption Support:** Encrypt and decrypt byte arrays for secure storage.
- **File Operations:** Save serialized objects to files and load them back.
- **Extension Methods:** Utilize convenient extension methods for clean and readable code.

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

### Serialization

Convert an object to a byte array:

```csharp
using ToBytes;

var myObject = new MyClass();
byte[] byteArray = myObject.ToBytes();
```

### Deserialization

Convert a byte array back to an object:

```csharp
using ToBytes;

MyClass myObject = byteArray.FromBytes<MyClass>();
```

### Encryption

Encrypt an object and convert it to a byte array:

```csharp
using ToBytes;

string password = "securepassword";
byte[] encryptedByteArray = myObject.ToBytesEncrypted(password);
```

Decrypt a byte array and convert it back to an object:

```csharp
using ToBytes;

MyClass decryptedObject = encryptedByteArray.FromEncryptedBytes<MyClass>(password);
```

### File Operations

Save an object to a file:

```csharp
using ToBytes;

string filePath = "path/to/file.bin";
myObject.ToBytesToFile(filePath);
```

Load an object from a file:

```csharp
using ToBytes;

MyClass myObject = ToBytesExtensions.FromBytesFromFile<MyClass>(filePath);
```

Save an encrypted object to a file:

```csharp
using ToBytes;

string filePath = "path/to/encryptedFile.bin";
string password = "securepassword";
myObject.ToEncryptedBytesToFile(filePath, password);
```

Load an encrypted object from a file:

```csharp
using ToBytes;

MyClass myObject = ToBytesExtensions.FromEncryptedBytesFromFile<MyClass>(filePath, password);
```

## Example

Here's a complete example demonstrating serialization, encryption, and file operations:

```csharp
using System;
using ToBytes;

public class MyClass
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Program
{
    public static void Main()
    {
        var myObject = new MyClass { Id = 1, Name = "Test" };

        // Serialize to byte array
        byte[] byteArray = myObject.ToBytes();

        // Deserialize from byte array
        MyClass deserializedObject = byteArray.FromBytes<MyClass>();

        // Encrypt and serialize to byte array
        string password = "securepassword";
        byte[] encryptedByteArray = myObject.ToBytesEncrypted(password);

        // Decrypt and deserialize from byte array
        MyClass decryptedObject = encryptedByteArray.FromEncryptedBytes<MyClass>(password);

        // Save to file
        string filePath = "path/to/file.bin";
        myObject.ToBytesToFile(filePath);

        // Load from file
        MyClass fileObject = ToBytesExtensions.FromBytesFromFile<MyClass>(filePath);

        // Save encrypted to file
        string encryptedFilePath = "path/to/encryptedFile.bin";
        myObject.ToEncryptedBytesToFile(encryptedFilePath, password);

        // Load encrypted from file
        MyClass encryptedFileObject = ToBytesExtensions.FromEncryptedBytesFromFile<MyClass>(encryptedFilePath, password);
    }
}
```
## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or suggestions, feel free to reach out via [GitHub Issues]([https://github.com/your-repo/byte-serializer/issues](https://github.com/Smando87/ToBytes/issues)).
```

