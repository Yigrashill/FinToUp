import React, { useState } from 'react'
import { Job } from '../../Types/Job';
import { Company } from '../../Types/Company';
import { jobService } from '../../Services/jobService';

const AddJobComp = () => {

    const [title, setTitle] = useState('');
    const [type, setType] = useState('Full-Time');

    const submitForm = (e : any) => {
        e.preventDefault();

        const newJob : Job = {
            title,
            type,
            id:0,
            description: '',
            location: '',
            salary: '',
            company: {
                name : '',
                description  : '',
                contactEmail : '',
                contactPhone : '',
            },
        };
    

        console.log(newJob);
        jobService.addJob(newJob);

    }

//   export  interface Company {
//     name : string;
//     description : string;
//     contactEmail : string;
//     contactPhone : string;
//   }


  return (
    <section className='bg-indigo-700 min-h-[960px]'>
       
        <div className="container m-auto max-w-6xl py-2">
        <h2 className="text-3xl text-white font-semibold mb-6 "> Add new Job </h2>
            <div className="bg-gray-100 px-6 py-8 mb-5 shadow-md rounded-md border m-4 md:m-0">
                <form onSubmit={submitForm}>

                    {/* Type */}
                    <div className="mb-4">
                        <label htmlFor="type"
                            className=' block text-blue-700 font-bold mb-2'>
                            Job Type
                        </label>
                        <select 
                            name="type" 
                            id="type"
                            className='font-bold border rounded w-full py-2 px-3'
                            required
                            value={type}
                            onChange={(e) => setType(e.target.value)}>
                                <option value='Full-Time'>Full-Time</option>
                                <option value='Part-Time'>Part-Time</option>
                                <option value='Remote'>Remote</option>
                                <option value='Internship'>Internship</option>
                        </select>
                    </div>

                    {/* Title */}
                    <div className="mb-4">
                        <label htmlFor='title'
                            className="block text-blue-700 font-bold mb-2">
                            Job Title
                        </label>
                        <input 
                            type="text"
                            id='title'
                            name='title'
                            className="border rounded font-bold w-full py-2 px-3 mb-2"
                            placeholder='Job Title'
                            required
                            value={title}
                            onChange={(e) => setTitle(e.target.value)}
                            />
                    </div>


                    <div>
              <button
                className='bg-indigo-500 hover:bg-indigo-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline'
                type='submit'
              >
                Add Job
              </button>
            </div>

                </form>
            </div>
        </div>

    </section>
  )
}

export default AddJobComp