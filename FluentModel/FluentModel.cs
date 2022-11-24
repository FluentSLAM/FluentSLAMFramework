namespace FluentSLAM;


public class FluentModel<TMobileObject, TMap, TPosition>
    where TMobileObject : IMobileObjectModel<TPosition>
    where TMap : IMapModel
{
    protected dynamic MotionModel { get; private set; }
    protected dynamic ObservationModel { get; private set; }
    protected TMobileObject MobileObject { get; private set; }
    protected TMap Map { get; private set; }

    #region BaseMethods

    public FluentModel<TMobileObject, TMap, TPosition> SetMotionModel<TDataEntry>(
        IMotionModel<TMobileObject, TPosition, TDataEntry> motionModel)
        where TDataEntry : struct
    {
        MotionModel = motionModel;
        return this;
    }


    public FluentModel<TMobileObject, TMap, TPosition> SetObservationModel<TDataEntry>(
        IObservationModel<IMapModel, TDataEntry> observationModel)
        where TDataEntry : struct
    {
        ObservationModel = observationModel;
        return this;
    }


    public FluentModel<TMobileObject, TMap, TPosition> UpdateMotionModel<TMotionModel, TDataEntry>(
        TMotionModel model,
        TDataEntry data)
        where TMotionModel : IMotionModel<TMobileObject, TPosition, TDataEntry>
        where TDataEntry : struct
    {
        ApplyMotionModel<TMotionModel, TDataEntry>(model, data);
        return this;
    }

    public FluentModel<TMobileObject, TMap, TPosition> UpdateMotionModel<TDataEntry>(TDataEntry data)
        where TDataEntry : struct
        => UpdateMotionModel(MotionModel, data);

    public FluentModel<TMobileObject, TMap, TPosition> UpdateObservationModel<TObservationModel, TDataEntry>(
        TObservationModel model,
        TDataEntry data)
        where TObservationModel : IObservationModel<TMap, TDataEntry>
        where TDataEntry : struct
    {
        ApplyObservationModel<TObservationModel, TDataEntry>(model, data);
        return this;
    }

    public FluentModel<TMobileObject, TMap, TPosition> UpdateObservationModel<TDataEntry>(TDataEntry data)
        where TDataEntry : struct
        => UpdateObservationModel(ObservationModel, data);
    #endregion

    #region VirtualMethods
    protected virtual void ApplyMotionModel<TMotionModel, TDataEntry>(
        TMotionModel model,
        TDataEntry data)
        where TMotionModel : IMotionModel<TMobileObject, TPosition, TDataEntry>
        where TDataEntry : struct
    => model.Apply(MobileObject, data);

    protected virtual void ApplyObservationModel<TObservationModel, TDataEntry>(
        TObservationModel model,
        TDataEntry data)
        where TObservationModel : IObservationModel<TMap, TDataEntry>
        where TDataEntry : struct
    => model.Apply(Map, data);
    #endregion
}
