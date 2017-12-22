using System;
using System.Collections.Generic;
using System.Text;

namespace PluralizationService.Core.Event
{
    /// <summary>
    /// This interface represents an object that performs event aggregation.
    /// </summary>
    /// <example>
    /// <b>Example of subscribing:</b>
    /// <code>
    /// bool eventWasRaised = false;
    /// var eventPublisher = new EventPublisher();
    ///
    /// eventPublisher.GetEvent{SampleEvent}()
    ///      .Subscribe(se => eventWasRaised = true);
    ///
    /// eventPublisher.Publish(new SampleEvent());
    /// // (eventWasRaised is now TRUE)
    /// </code>
    /// <b>Example of un-subscribing:</b>
    /// <code>
    /// bool eventWasRaised = false;
    /// var eventPublisher = new EventPublisher();
    /// 
    /// var subscription = eventPublisher.GetEvent{SampleEvent}()
    ///     .Subscribe(se => eventWasRaised = true);
    /// 
    /// subscription.Dispose();
    /// eventPublisher.Publish(new SampleEvent());
    /// // (eventWasRaised is still FALSE, do to the un-subscribe.)
    /// </code>
    /// <b>Example of a selectively subscribing:</b>
    /// <code>
    /// bool eventWasRaised = false;
    /// var eventPublisher = new EventPublisher();
    /// 
    /// eventPublisher.GetEvent{SampleEvent}()
    /// .Where(se => se.Status == 1)
    /// .Subscribe(se => eventWasRaised = true);
    /// 
    /// eventPublisher.Publish(new SampleEvent{Status = 1});
    /// // (eventWasRaised is now TRUE)
    /// </code>
    /// <b>Example of subscribe to projection:</b>
    /// <code>
    /// bool eventWasRaised = false;
    /// var eventPublisher = new EventPublisher();
    /// 
    /// eventPublisher.GetEvent{SampleEvent}()
    ///      .Select(se => se.Status)
    ///      .Subscribe(status => Console.WriteLine(status));
    /// 
    /// eventPublisher.Publish(new SampleEvent{Status = 1});
    /// </code>
    /// <b>Example of observing on dispatcher:</b>
    /// <code>
    /// bool eventWasRaised = false;
    /// var eventPublisher = new EventPublisher();
    /// 
    /// eventPublisher.GetEvent{SampleEvent}()
    ///      .ObserveOnDispatcher()
    ///      .Select(se => se.Status)
    ///      .Subscribe(status => Console.WriteLine(status));
    /// 
    /// eventPublisher.Publish(new SampleEvent{Status = 1});
    /// </code>
    /// </example>
    public interface IEventAggregator
    {
        /// <summary>
        /// This method publishes an event.
        /// </summary>
        /// <typeparam name="TEvent">The type to associate with the event.</typeparam>
        /// <param name="eventArgs">The event arguments.</param>
        void Publish<TEvent>(
            TEvent eventArgs
        ) where TEvent : class;

        /// <summary>
        /// This method provides access to an event.
        /// </summary>
        /// <typeparam name="TEvent">The type to associate with the event.</typeparam>
        /// <returns>An <see cref="IObservable{T}"/> reference.</returns>
        IObservable<TEvent> GetEvent<TEvent>()
            where TEvent : class;
    }
}
