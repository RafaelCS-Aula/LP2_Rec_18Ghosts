
/// <summary>
/// Interface to be implemented by any unity class that interfaces with the
/// Model and its BridgeClasses
/// </summary>
public interface IModelConnector 
{
    /// <summary>
    /// Method to serve as a replacement for Start(). Making sure it's called
    /// by the GameStarter at the right time to avoid conflicts with the Model.
    /// </summary>
    void Initialize();
}
