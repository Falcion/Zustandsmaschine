using Zustandsmaschine.Items.Attributes;
using Zustandsmaschine.Exceptions.Attributes;

using Briefmaschine.Objects.Tupples;

namespace Zustandsmaschine.Enums
{
    /// <summary>
    /// An enum which defines set of shifts of current flow
    /// </summary>
    public enum Shifts : uint
    {
        /// <summary>
        /// Enum value representing status with subsignature BEGIN for shift of flow
        /// </summary>
        [Shift("BEGIN", true)]
        BEGIN,
        /// <summary>
        /// Enum value representing status with subsignature PAUSE for shift of flow
        /// </summary>
        [Shift("PAUSE", true)]
        PAUSE,
        /// <summary>
        /// Enum value representing status with subsignature RESUME for shift of flow
        /// </summary>
        [Shift("RESUME", true)]
        RESUME,
        /// <summary>
        /// Enum value representing status with subsignature EXIT for shift of flow
        /// </summary>
        [Shift("EXIT", true)]
        EXIT,
        /// <summary>
        /// Enum value representing status with subsignature STOP for shift of flow
        /// </summary>
        [Shift("STOP", true)]
        STOP,
        /// <summary>
        /// Enum value representing status with subsignature PHASE for shift of flow
        /// </summary>
        [Shift("PHASE", false)]
        PHASE,
        /// <summary>
        /// Enum value representing status with subsignature STAGE for shift of flow
        /// </summary>
        [Shift("STAGE", false)]
        STAGE,
        /// <summary>
        /// Enum value representing status with subsignature MOMENTUM for shift of flow
        /// </summary>
        [Shift("MOMENTUM", false)]
        MOMENTUM,
    }

    /// <summary>
    /// A class which defines methods and functions of extension format to work with shifts enum
    /// </summary>
    public static class ShiftsExtensions
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
        public static Trupple<dynamic> GetShiftAttributes(Type type)
        {
            var attribute = (ShiftAttribute?)Attribute.GetCustomAttribute(type, typeof(ShiftAttribute));

            if (attribute == null)
                throw new NullableFlowAttributeException("Given attribute either is not shift's attribute or just NULL.");

            return new Trupple<dynamic>(attribute.Name,
                                        attribute.Data,
                                        attribute.Stable);
        }

        /// <summary>
        /// Static function getting attribute current name for assigned shift
        /// </summary>
        /// <param name="type">
        /// Assembly type instance representing a type of object's serialization
        /// </param>
        /// <returns>
        /// String value displaying current name for assigned shift
        /// </returns>
        /// <exception cref="NullableFlowAttributeException">
        /// Thrown when assembly type instance is null and no any information could be taken away from it
        /// </exception>
        public static string? GetAttributeName(Type type)
        {
            var AttST = GetShiftAttributes(type);

            if (AttST.P1 == null || AttST.P1 == string.Empty)
                return null;

            return AttST.P1;
        }

        /// <summary>
        /// Static function getting attribute byte-stable data in MD5's formatting for assigned shift
        /// </summary>
        /// <param name="type">
        /// Assembly type instance representing a type of object's serialization
        /// </param>
        /// <returns>
        /// Array of byte data in MD5's format displaying direction of instablity for instance of shift
        /// </returns>
        /// <exception cref="NullableFlowAttributeException">
        /// Thrown when assembly type instance is null and no any information could be taken away from it
        /// </exception>
        public static byte[]? GetAttributeData(Type type)
        {
            var AttST = GetShiftAttributes(type);

            if (AttST.P2 == null || AttST.P2 == Array.Empty<byte>())
                return Array.Empty<byte>();

            return AttST.P2;
        }

        /// <summary>
        /// Static function getting attribute boolean parameter for stable check for assigned shift
        /// </summary>
        /// <param name="type">
        /// Assembly type instance representing a type of object's serialization
        /// </param>
        /// <returns>
        /// Boolean parameter displaying is this attribute assigned to stable neither non-stable shift
        /// </returns>
        /// <exception cref="NullableFlowAttributeException">
        /// Thrown when assembly type instance is null and no any information could be taken away from it
        /// </exception>
        public static bool? GetAttributesStable(Type type)
        {
            var AttST = GetShiftAttributes(type);

            if (AttST.P3 == null)
                return null;

            return AttST.P2;
        }

        /// <summary>
        /// Static function parsing shift upper attribute name from integer value
        /// </summary>
        /// <param name="id">
        /// An unsigned 32-bit integer value representing an integer value for an enum of shift
        /// </param>
        /// <returns>
        /// String value representing upper case attribute name of enum
        /// </returns>
        public static string ConrID(uint id)
        {
            switch (id)
            {
                case 1:
                    return "PAUSE";
                case 2:
                    return "RESUME";
                case 3:
                    return "EXIT";
                case 4:
                    return "STOP";
                case 5:
                    return "PHASE";
                case 6:
                    return "STAGE";
                case 7:
                    return "MOMENTUM";
                default:
                    return "BEGIN";
            }
        }

        /// <summary>
        /// Static function parsing shift integer value from upper attribute name
        /// </summary>
        /// <param name="name">
        /// String value representing upper case attribute name of enum
        /// </param>
        /// <returns>
        /// An unsigned 32-bit integer value representing an integer value for an enum of shift
        /// </returns>
        public static uint ConrSTRING(string name)
        {
            var ENUM = name.ToUpper();

            switch (ENUM)
            {
                case "PAUSE":
                    return 1;
                case "RESUME":
                    return 2;
                case "EXIT":
                    return 3;
                case "STOP":
                    return 4;
                case "PHASE":
                    return 5;
                case "STAGE":
                    return 6;
                case "MOMENTUM":
                    return 7;
                default:
                    return 0;
            }
        }
    }
}