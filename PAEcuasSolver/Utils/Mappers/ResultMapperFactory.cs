namespace PAEcuasSolver.Utils.Mappers
{
    public static class ResultMapperFactory
    {
        public static IResultMapper GetMapper(string type)
        {
            return type switch
            {
                "MAS" => new MASResultMapper(),

                // futuros:
                // "MVA" => new MVAResultMapper(),

                _ => throw new NotImplementedException("No hay mapper para ese tipo")
            };
        }
    }
}