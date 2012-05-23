using System;
using System.Linq;
using System.Text;

namespace Gojo.Core.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class SensitiveInformationAttribute : Attribute
    {
        /// <summary>
        /// Default string top display when not hidden.
        /// </summary>
        private const string DefaultStringValue = "PII";

        /// <summary>
        /// String value to display when not hidden.
        /// </summary>
        private string displayOverride;

        /// <summary>
        /// Initializes a new instance of the PersonallyIdentifiableInformationAttribute class.
        /// </summary>
        public SensitiveInformationAttribute()
        {
            this.Hidden = true;
        }

        /// <summary>
        /// Initializes a new instance of the PersonallyIdentifiableInformationAttribute class.
        /// </summary>
        /// <param name="displayOverride">Value to display in ToString.</param>
        public SensitiveInformationAttribute(string displayOverride)
        {
            this.Hidden = false;
            this.displayOverride = displayOverride;
        }

        /// <summary>
        /// Gets the string override value when marked as PII.
        /// </summary>
        public string DisplayOverride
        {
            get
            {
                return string.IsNullOrEmpty(this.displayOverride) ? DefaultStringValue : this.displayOverride;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the value should be totally hidden.
        /// </summary>
        public bool Hidden { get; set; }

    }
}
