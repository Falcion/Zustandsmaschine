# Official XML Comment Style and Conventions for Zustandsmaschine

XML comments play a crucial role in documenting code in Zustandsmaschine, providing essential information about classes, methods, fields, and more. Consistent and well-defined XML comment conventions enhance code readability, facilitate maintenance, and promote effective collaboration among developers. In this article, we present the official XML comment style and conventions for Zustandsmaschine, covering a wide range of scenarios and coding elements.

## Classes, Enums, Interfaces, and Objects

When documenting classes, enums, interfaces, and other objects, follow these conventions:

- **Summary**: Begin the summary with the appropriate article ("a" or "an") followed by a description that conveys the purpose of the object. Use phrases such as "which represents" or "which defines" to provide a clear understanding of the object's role.

## Constructors

Constructors, responsible for creating instances of classes, should follow these guidelines:

- **Summary**: The constructor summary should start with "Constructor of instance for [CLASS]" to indicate its purpose and relevance.
- **Parameter Summary**: Clone the summary used for class fields and append "for the current instance" to describe constructor parameters.

## Exceptions

When documenting exceptions, follow these conventions:

- **Summary**: Begin with "Thrown when [ETC]" to clearly state the circumstances under which the exception is thrown.

## Delegates, Getters, and Setters

Delegates, public getters, and setters should adhere to these conventions:

- **Delegate and Getter Summary**: Clone the summary used for fields to describe the delegate or getter.
- **Setter Summary**: For setters, start with "Set the [FIELD] [FIELD_DESC]" to convey the purpose of the setter.

## Methods and Functions

Methods and functions should adhere to the following conventions:

- **Method Summary**: Start with "METHOD V+ing..." for methods or "FUNCTION V+ing..." for functions to indicate the action performed by the method or function.
- **Static Methods**: If a method is static, use "static method..." or "static function..." in the summary to denote its static nature.
- **Return Value**: For methods/functions with a return value, clone the summary used for the corresponding field. If the return value is not directly related to a field, provide a concise summary explaining the returned value.
- **Exceptions**: Document exceptions thrown by methods using the `<exception>` tag, specifying the exception type and providing a brief description of when and why the exception is thrown.

## Records and Structs

When documenting records and structs, follow these conventions:

- **Summary**: Start with "Immutable record representing" for records or "Immutable struct representing" for structs to indicate their immutability and purpose.

## Generic Types

When documenting generic types, follow these conventions:

- **Summary**: Begin with "Generic type representing" followed by a description of the type's purpose and usage. If applicable, include details about the constraints imposed on the generic type.

## Fields

Fields, representing various data types, should follow these conventions:

- **Booleans**: Begin with "Boolean parameter V+ing" to describe a boolean field.
- **Arrays of Bytes**: Use "Array of byte data" to indicate an array of bytes.
- **Other Field Types**: Include "[TYPE] value" or "[TYPE] instance" (for class fields) followed by the verb "V+ing..." to describe the field.
  - For specific types such as INT, UINT, LONG, DOUBLE, FLOAT, DECIMAL, ENUM, and CLASS, use appropriate descriptions (e.g., "A 32-bit integer value,"

 "Enum classified value," "Classified value," etc.).
  - For lists, describe them as "Dynamic array of [type in multiple: 32-bit integers, strings, etc.]"

---

These XML comment conventions provide a comprehensive guide for documenting various elements in C# codebase, ensuring consistency, clarity, and ease of understanding for developers who work on Zustandsmaschine. Adhering to these conventions will improve code readability, maintainability, and collaboration within development team.

---

# Effective Use of Tags in XML Comments

XML comments serve as a powerful tool for documenting code in Zustandsmaschine, providing valuable information to developers who interact with your codebase. In addition to plain text descriptions, XML comments allow the use of various tags to enhance the documentation's clarity and functionality. This article explores the effective use of tags in XML comments, including popular tags such as "keyword," "cref," "paramref," "see," and "seealso," as well as the "href" tag for linking external resources.

## The "keyword" Tag

The "keyword" tag is useful for highlighting specific terms or keywords within your XML comments. By wrapping a keyword within the "keyword" tag, you can draw attention to important concepts, APIs, or conventions related to your code. For example:

```csharp
/// <summary>
/// This method performs a <keyword>deep copy</keyword> of the provided object.
/// </summary>
public static T DeepCopy<T>(T obj)
{
    // Implementation details
}
```

Using the "keyword" tag makes it easier for developers to identify and understand the key concepts mentioned in the documentation.

## The "cref" Tag

The "cref" tag allows you to reference code elements, such as types, members, or parameters, within your XML comments. This tag creates a hyperlink to the referenced element, enabling developers to navigate directly to the relevant code. Here's an example of using the "cref" tag:

```csharp
/// <summary>
/// This method returns an instance of the <cref="System.String"/> class.
/// </summary>
public static string GetString()
{
    // Implementation details
}
```

By using the "cref" tag, you establish a clear connection between the documentation and the actual code, providing convenient access to the referenced elements.

## The "paramref" Tag

The "paramref" tag is used to refer to a specific parameter within your XML comments. It allows you to provide additional context or clarification regarding the purpose or usage of a parameter. Consider the following example:

```csharp
/// <summary>
/// Sets the value of the specified <paramref name="propertyName"/>.
/// </summary>
/// <param name="propertyName">The name of the property to set.</param>
/// <param name="value">The value to assign to the property.</param>
public void SetProperty(string propertyName, object value)
{
    // Implementation details
}
```

Using the "paramref" tag improves the readability and understanding of your documentation by explicitly referencing individual parameters.

## The "see" and "seealso" Tags

The "see" and "seealso" tags are powerful tools for linking to related code elements or external resources. The "see" tag allows you to create a link to a specific type, member, or keyword within your codebase, while the "seealso" tag enables you to provide additional references or recommended resources. Here's an example:

```csharp
/// <summary>
/// This method utilizes the <see cref="SomeClass"/> to perform a specific operation.
/// For more information, see <seealso href="https://example.com/documentation">the official documentation</seealso>.
/// </summary>
public void PerformOperation()
{
    // Implementation details
}
```

By using the "see" and "seealso" tags, you can establish connections to related code elements or external documentation, enhancing the discoverability and comprehension of your code.

## The "href" Tag

In addition to linking to code elements, XML comments in Zustandsmaschine also support linking to external resources using the "href" tag. This tag allows you

 to specify a URL that points to relevant documentation, specifications, tutorials, or any other online resource. Here's an example:

```csharp
/// <summary>
/// For more details, refer to the official <href="https://example.com/api-reference">API reference</href>.
/// </summary>
public void SomeMethod()
{
    // Implementation details
}
```

Using the "href" tag, you can conveniently direct developers to external resources that provide further information or context related to your code.

## Conclusion

By utilizing tags like "keyword," "cref," "paramref," "see," "seealso," and "href" in your XML comments, you can significantly enhance the documentation for your contribution in Zustandsmaschine. These tags provide additional context, establish connections between different code elements, and enable convenient access to related information. Adopting consistent and effective use of these tags will result in improved code comprehension, better collaboration, and enhanced overall developer experience.