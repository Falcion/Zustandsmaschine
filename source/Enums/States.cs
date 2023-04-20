using Zustandsmaschine.Items.Attributes;
using Zustandsmaschine.Exceptions.Attributes;

using Briefmaschine.Objects.Tupples;

namespace Zustandsmaschine.Enums
{
    /// <summary>
    /// An enum which defines set of shifts of current flow
    /// </summary>
    public enum States : uint
    {
        /// <summary>
        /// Enum value representing status with signature UNKNOWN for state of flow
        /// </summary>
        [State("UNKNOWN", false)]
        UNKNOWN,
        /// <summary>
        /// Enum value representing status with signature FAILED for state of flow
        /// </summary>
        [State("FAILED", false)]
        FAILED,
        /// <summary>
        /// Enum value representing status with signature STAGED for state of flow
        /// </summary>
        [State("STAGED", false)]
        STAGED,
        /// <summary>
        /// Enum value representing status with signature SKIPPED for state of flow
        /// </summary>
        [State("SKIPPED", true)]
        SKIPPED,
        /// <summary>
        /// Enum value representing status with signature PROCESSING for state of flow
        /// </summary>
        [State("PROCESSING", true)]
        PROCESSING,
        /// <summary>
        /// Enum value representing status with signature SUCCESSFUL for state of flow
        /// </summary>
        [State("SUCCESSFUL", true)]
        SUCCESSFUL,
    }

    /// <summary>
    /// A class which defines methods and functions of extension format to work with states enum
    /// </summary>
    public static class StateExtensions
    {
        /// <summary>
        /// Static function getting attribute from given type of object
        /// </summary>
        /// <param name="type">
        /// Assembly type instance representing a type of object's serialization
        /// </param>
        /// <returns>
        /// Three-parametered set of generics defining an full result of getting attribute fields
        /// </returns>
        /// <exception cref="NullableFlowAttributeException">
        /// Thrown when assembly type instance is null and no any information could be taken away from it
        /// </exception>
        public static Trupple<dynamic> GetStateAttributes(Type type)
        {
            var attribute = (StateAttribute?)Attribute.GetCustomAttribute(type, typeof(StateAttribute));

            if (attribute == null)
                throw new NullableFlowAttributeException("Given attribute either is not state's attribute or just NULL.");

            return new Trupple<dynamic>(attribute.Name,
                                        attribute.Data,
                                        attribute.Stable);
        }

        /// <summary>
        /// Static function getting attribute current name for assigned state
        /// </summary>
        /// <param name="type">
        /// Assembly type instance representing a type of object's serialization
        /// </param>
        /// <returns>
        /// String value displaying current name for assigned state
        /// </returns>
        /// <exception cref="NullableFlowAttributeException">
        /// Thrown when assembly type instance is null and no any information could be taken away from it
        /// </exception>
        public static string? GetAttributeName(Type type)
        {
            var AttST = GetStateAttributes(type);   

            if (AttST.P1 == null || AttST.P1 == string.Empty)
                return null;

            return AttST.P1;
        }

        /// <summary>
        /// Static function getting attribute byte-stable data in SHA256's formatting for assigned state
        /// </summary>
        /// <param name="type">
        /// Assembly type instance representing a type of object's serialization
        /// </param>
        /// <returns>
        /// Array of byte data in SHA256's format displaying direction of instablity for instance of state
        /// </returns>
        /// <exception cref="NullableFlowAttributeException">
        /// Thrown when assembly type instance is null and no any information could be taken away from it
        /// </exception>
        public static byte[]? GetAttributeData(Type type)
        {
            var AttST = GetStateAttributes(type);

            if (AttST.P2 == null || AttST.P2 == Array.Empty<byte>())
                return Array.Empty<byte>();

            return AttST.P2;
        }

        /// <summary>
        /// Static function getting attribute boolean parameter for stable check for assigned state
        /// </summary>
        /// <param name="type">
        /// Assembly type instance representing a type of object's serialization
        /// </param>
        /// <returns>
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable state
        /// </returns>
        /// <exception cref="NullableFlowAttributeException">
        /// Thrown when assembly type instance is null and no any information could be taken away from it
        /// </exception>
        public static bool? GetAttributesStable(Type type)
        {
            var AttST = GetStateAttributes(type);

            if (AttST.P3 == null)
                return null;

            return AttST.P2;
        }

        /// <summary>
        /// Static function parsing state upper attribute name from integer value
        /// </summary>
        /// <param name="id">
        /// An unsigned 32-bit integer value representing an integer value for an enum of state
        /// </param>
        /// <returns>
        /// String value representing upper case attribute name of enum
        /// </returns>
        public static string ConrID(uint id)
        {
            switch(id)
            {
                case 1:
                    return "FAILED";
                case 2:
                    return "STAGED";
                case 3:
                    return "SKIPPED";
                case 4:
                    return "PROCESSING";
                case 5:
                    return "SUCCESSFUL";
                default:
                    return "UNKNOWN";
            }
        }

        /// <summary>
        /// Static function parsing state integer value from upper attribute name
        /// </summary>
        /// <param name="name">
        /// String value representing upper case attribute name of enum
        /// </param>
        /// <returns>
        /// An unsigned 32-bit integer value representing an integer value for an enum of state
        /// </returns>
        public static uint ConrSTRING(string name)
        {
            var ENUM = name.ToUpper();

            switch(ENUM)
            {
                case "FAILED":
                    return 1;
                case "STAGED":
                    return 2;
                case "SKIPPED":
                    return 3;
                case "PROCESSING":
                    return 4;
                case "SUCCESSFUL":
                    return 5;
                default:
                    return 0;
            }
        }
    }
}