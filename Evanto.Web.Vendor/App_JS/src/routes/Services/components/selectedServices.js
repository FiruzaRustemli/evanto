import React from 'react'

const SelectedServices = (props) => {
    return (
        <table className='table'>
            <thead>
            </thead>
            <tbody>
                {props.services.map((item, key) => {
                    return (
                        <tr key={key}>
                            <td>{item.name}</td>
                            <td>{`${item.duration} ${props['##day']}`}</td>
                            <td>{`${item.price} ${props['##azn']}`}</td>
                        </tr>
                    )
                })}
            </tbody>
        </table>
    )
}
export default SelectedServices