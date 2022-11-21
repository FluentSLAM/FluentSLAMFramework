namespace FluentSLAM;


public class FluentModel
{
    protected dynamic CorrectionModel { get; private set; }
    protected dynamic PredictionModel { get; private set; }
    protected dynamic MobileObject { get; private set; }
    protected dynamic Map { get; private set; }

    #region BaseMethods
    public FluentModel SetCorrectionModel<TDataEntry>(
        IObservationModel<IMapModel, TDataEntry> correctionModel)
        where TDataEntry : struct
    {
        CorrectionModel = correctionModel;
        return this;
    }

    public FluentModel SetPredictionModel<TPosition, TDataEntry>(
        IMotionModel<TPosition, TDataEntry> predictionModel)
        where TDataEntry : struct
    {
        PredictionModel = predictionModel;
        return this;
    }

    public virtual FluentModel Initialize<TInitModel>()
    {
        return this;
    }

    public FluentModel UpdateMotionModel<TMotionModel, TDataEntry, TPosition>(
        TMotionModel model,
        TDataEntry data)
        where TMotionModel : IMotionModel<TPosition, TDataEntry>
        where TDataEntry : struct
    {
        ApplyMotionModel<TMotionModel, TDataEntry, TPosition>(model, data);
        return this;
    }

    public FluentModel UpdateMotionModel<TPosition, TDataEntry>(TDataEntry data)
        where TDataEntry : struct
        => UpdateMotionModel(PredictionModel, data);

    public FluentModel UpdateObservationModel<TObservationModel, TDataEntry, TMap>(
        TObservationModel model,
        TDataEntry data)
        where TObservationModel: IObservationModel<TMap, TDataEntry>
        where TDataEntry : struct
        where TMap : IMapModel
    {
        ApplyObservationModel<TObservationModel, TDataEntry, TMap>(model, data);
        return this;
    }

    public FluentModel UpdateObservationModel<TDataEntry>(TDataEntry data)
        where TDataEntry : struct
        => UpdateObservationModel(CorrectionModel, data);
    #endregion

    #region VirtualMethods
    protected virtual void ApplyMotionModel<TMotionModel, TDataEntry, TPosition>(
        TMotionModel model,
        TDataEntry data)
        where TMotionModel : IMotionModel<TPosition, TDataEntry>
        where TDataEntry : struct
    => model.Apply(MobileObject, data);

    protected virtual void ApplyObservationModel<TObservationModel, TDataEntry, TMap>(
        TObservationModel model,
        TDataEntry data)
        where TObservationModel : IObservationModel<TMap, TDataEntry>
        where TDataEntry : struct
        where TMap : IMapModel
    => model.Apply(Map, data);
    #endregion
}
