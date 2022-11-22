﻿using NeerCore.Exceptions;

namespace NeerCore.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    ///   Returns the first element of a sequence, or throws a
    ///   <see cref="NotFoundException"/> if the sequence contains no elements.
    /// </summary>
    /// <param name="source">The <see cref="IEnumerable{T}"/> to return the first element of.</param>
    /// <param name="errorMessage">The error message that will be threw instead of the default one when an exception occurs.</param>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <returns>Found entity or throws 404 exception.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
    /// <exception cref="NotFoundException"><paramref name="source"/> is empty.</exception>
    public static TSource FirstOr404<TSource>(this IEnumerable<TSource> source, string? errorMessage = null)
    {
        return source.FirstOrDefault() ?? throw CreateNotFoundException<TSource>(errorMessage);
    }

    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <inheritdoc cref="FirstOr404{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>
    public static TSource FirstOr404<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, string? errorMessage = null)
    {
        return source.FirstOrDefault(predicate) ?? throw CreateNotFoundException<TSource>(errorMessage);
    }


    private static NotFoundException CreateNotFoundException<TSource>(string? errorMessage)
    {
        return string.IsNullOrEmpty(errorMessage)
            ? new NotFoundException<TSource>()
            : new NotFoundException(errorMessage);
    }
}