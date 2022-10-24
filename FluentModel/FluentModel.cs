namespace FluentSLAM;


public class FluentModel
{
    protected dynamic CorrectionModel { get; private set; }
    protected dynamic PredictionModel { get; private set; }
    protected IMobileObjectModel MobileObject { get; private set; }
    protected IMapModel Map { get; private set; }
    

    public FluentModel SetCorrectionModel<TDataEntry>(
        ICorrectionModel<TDataEntry> correctionModel)
        where TDataEntry : struct
    {
        CorrectionModel = correctionModel;
        return this;
    }

    public FluentModel SetPredictionModel<TDataEntry>(
        IPredictionModel<TDataEntry> predictionModel)
        where TDataEntry : struct
    {
        PredictionModel = predictionModel;
        return this;
    }

    public virtual FluentModel Initialize<TInitModel>()
    {
        return this;
    }

    public virtual FluentModel Predict<TDataEntry>(
        IPredictionModel<TDataEntry> model,
        TDataEntry data)
        where TDataEntry : struct
    {
        model.Apply(MobileObject, data);
        return this;
    }

    public FluentModel Predict<TDataEntry>(TDataEntry data)
        where TDataEntry : struct
        => Predict(PredictionModel, data);

    public virtual FluentModel Correct<TDataEntry>(
        ICorrectionModel<TDataEntry> model,
        TDataEntry data)
        where TDataEntry : struct
    {
        model.Apply(Map, data);
        return this;
    }

    public FluentModel Correct<TDataEntry>(TDataEntry data)
        where TDataEntry : struct
        => Correct(CorrectionModel, data);
}
