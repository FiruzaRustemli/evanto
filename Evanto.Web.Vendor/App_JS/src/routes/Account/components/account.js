import React from 'react'
import Cover from './cover'
import PersonalInfo from '../containers/personalInfo'

const Account = () => {
    return (
        <section style={{ padding:0 }}>
            <Cover  />
            <section>
                <div className='section-body no-margin'>
                    <div className='row'>
                        <PersonalInfo />
                        <PersonalInfo />
                    </div>
                </div>
            </section>
        </section>
    )
}

export default Account