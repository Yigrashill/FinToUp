import React from 'react'

const Hero = ({
    title = 'Way of money ',
    subtilte = 'My money...'}) => {

  return (
    <section className='py-20 bg-gray-800 '>
        <div className="max-w-7xl mx-auto sm:px-6 lg:px-8 flex flex-col">
            <div className="text-center text-white">
                <h1 className="text-4xl font-extrabold sm:text-5xl md:text-6xl">
                    {title}
                </h1>
            </div>
        </div>
    </section>
  )
}

export default Hero