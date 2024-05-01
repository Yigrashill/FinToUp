import React from 'react'
import JobList from '../Components/Jobs/JobList'

const JobsPage = () => {
  return (
    <section className='bg-indigo-700 px-4 py-6'>
        <JobList isHome ={false} />
    </section>
  )
}

export default JobsPage