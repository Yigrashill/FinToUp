import React from 'react'
import Hero from '../Components/Hero'
import HomeCards from '../Components/Cards/HomeCards'
import JobList from '../Components/Jobs/JobList'
import ViewAllJobs from '../Components/Jobs/ViewAllJobs'

const HomePage = () => {
  return (
    <>
        <HomeCards />
        <section className="bg-blue-800 px-4 py-10">
          <JobList isHome={true} />
        </section>
        <ViewAllJobs />
    </>
  )
}

export default HomePage