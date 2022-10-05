namespace FluentSLAM;


public abstract class FluentModel
{
    protected ICorrectionModel CorrectionModel { get; private set; }
    protected IPredictionModel PredictionModel { get; private set; }
    protected MobileObjectModel MobileObject { get; private set; }
    protected MapModel Map { get; private set; }
    

    public FluentModel SetCorrectionModel(ICorrectionModel correctionModel)
    {
        CorrectionModel = correctionModel;
        return this;
    }

    public FluentModel SetPredictionModel(IPredictionModel predictionModel)
    {
        PredictionModel = predictionModel;
        return this;
    }

    public virtual FluentModel Initialize<TInitModel>()
    {
        return this;
    }

    public virtual FluentModel Predict(IPredictionModel model, DataEntity data)
    {
        model.Apply(MobileObject, data);
        return this;
    }

    public FluentModel Predict(DataEntity data)
        => Predict(PredictionModel, data);

    public virtual FluentModel Correct(ICorrectionModel model, DataEntity data)
    {
        model.Apply(Map, data);
        return this;
    }

    public FluentModel Correct(DataEntity data)
        => Correct(CorrectionModel, data);
}
