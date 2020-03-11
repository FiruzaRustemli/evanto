import React from 'react'
import EventCalendar from 'react-event-calendar'
import '../../../styles/calendar.scss'
export const Counter = (props) => {

  return (
      <div style={{ margin: '0 auto' }} >
        <h2>Counter: {props.counter}</h2>
        <button className='btn btn-default' onClick={props.increment}>
          Increment
    </button>

        {' '}
        < button className='btn btn-default' onClick={props.doubleAsync}>
          Double (Async)
    </button>

        <Card title="Card title" extra={<a href="#">More</a>} style={{ width: 300 }}>
          <p>Card content</p>
          <p>Card content</p>
          <p>Card content</p>
        </Card>
      </div>
  )
}

Counter.propTypes = {
  counter: React.PropTypes.number.isRequired,
  doubleAsync: React.PropTypes.func.isRequired,
  increment: React.PropTypes.func.isRequired
}

export default Counter
