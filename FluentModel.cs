namespace FluentSLAM;


public abstract class FluentModel
{
    protected ICorrectionModel SavedCorrectionModel { get; private set; }
    protected IPredictionModel SavedPredictionModel { get; private set; }
    protected MobileObjectModel MobileObject { get; private set; }
    protected MapModel Map { get; private set; }

    public virtual FluentModel Initialize<TInitModel>()
    {
        return this;
    }

    public virtual FluentModel
        Predict<TPredictionModel>(TPredictionModel model, object data)
        where TPredictionModel : IPredictionModel
    {
        model.Apply(MobileObject, data);
        return this;
    }
    public FluentModel Predict(object data)
        => Predict(SavedPredictionModel, data);

    public virtual FluentModel
        Correct<TCorrectionModel>(TCorrectionModel model, object data)
        where TCorrectionModel : ICorrectionModel
    {
        model.Apply(Map, data);
        return this;
    }

    public FluentModel Correct(object data)
        => Correct(SavedCorrectionModel, data);
}
