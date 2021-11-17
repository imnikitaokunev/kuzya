namespace Application.Models.Settings
{
    public class Parameter
    {
        /// <summary>
        /// Defines nice readable parameter name for the developer.
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Parameter name to be used in the request.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Parameter value to be used in the request.
        /// </summary>
        public string Value { get; set; }
    }
}
