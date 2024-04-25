import React from 'react'
import Navbar from './Components/Navbar'
import Hero from './Components/Hero'
import HomeCards from './Components/Cards/HomeCards'
import JobList from './Components/Jobs/JobList'


const App = () => {
  return (
    <>
      <Navbar />
      <Hero />
      <HomeCards />

      <JobList />

    </>
  )
}

export default App