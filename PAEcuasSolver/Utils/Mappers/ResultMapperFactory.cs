namespace PAEcuasSolver.Utils.Mappers
{
    public static class ResultMapperFactory
    {
        public static IResultMapper GetMapper(string type)
        {
            return type switch
            {
                "MVA" => new MVAResultMapper(),
                "MAS" => new MASResultMapper(),
                "MVF" => new MVFResultMapper(),

                _ => throw new NotImplementedException("No hay mapper para ese tipo")
            };
        }
    }
}