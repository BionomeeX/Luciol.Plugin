namespace Luciol.Plugin.Context.Annotation
{
    /// <summary>
    /// How the annotation is displayed on the triangles
    /// </summary>
    public enum DrawType
    {
        /// <summary>
        /// Small mark at the annotation position
        /// </summary>
        Normal,
        /// <summary>
        /// Additionnally to the small mark, add lines over the width and heigh of the position to mark the annotation through the full triangle
        /// </summary>
        Cross,
    }
}
