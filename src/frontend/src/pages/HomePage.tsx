import React from 'react'
import Hero from '../Components/Hero'
import HomeCards from '../Components/Cards/HomeCards'
import JobList from '../Components/Jobs/JobList'
import ViewAllJobs from '../Components/Jobs/ViewAllJobs'

const HomePage = () => {
  return (
    <>
        <Hero />
        <HomeCards />
        <JobList />
        <ViewAllJobs />
    </>
  )
}

export default HomePage