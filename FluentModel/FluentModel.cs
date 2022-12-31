namespace FluentSLAM;

public class FluentModel<TMobileObject, TMap>
    where TMobileObject : IMobileObjectModel
    where TMap : IMapModel
{
    protected virtual TMobileObject MobileObject { get; private set; }
    protected virtual TMap Map { get; private set; }

    public FluentModel(TMobileObject mobileObject, TMap map)
    {
        MobileObject = mobileObject;
        Map = map;
    }

    #region BaseMethods

    public FluentModel<TMobileObject, TMap> UpdateMotionModel<TDataEntry>(
        IMotionModel<TMobileObject, TDataEntry> model,
        TDataEntry data)
        where TDataEntry : struct
    {
        ApplyMotionModel<TDataEntry>(model, data);
        return this;
    }

    public FluentModel<TMobileObject, TMap> UpdateObservationModel<TDataEntry>(
        IObservationModel<TMap, TDataEntry> model,
        TDataEntry data)
        where TDataEntry : struct
    {
        ApplyObservationModel<TDataEntry>(model, data);
        return this;
    }

    #endregion

    #region VirtualMethods

    protected virtual void ApplyMotionModel<TDataEntry>(
        IMotionModel<TMobileObject, TDataEntry> model,
        TDataEntry data)
        where TDataEntry : struct
        => model.Apply(MobileObject, data);

    protected virtual void ApplyObservationModel<TDataEntry>(
        IObservationModel<TMap, TDataEntry> model,
        TDataEntry data)
        where TDataEntry : struct
        => model.Apply(Map, data);

    #endregion
}