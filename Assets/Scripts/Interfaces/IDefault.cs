namespace Atrabile.Interfaces {
public interface IDefault<T> where T : class {

    public static T Default() => null;

}} // namespace ..
