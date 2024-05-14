import React, { useState } from 'react'
import { Job } from '../../Types/Job';
import { Company } from '../../Types/Company';
import { jobService } from '../../Services/jobService';
import { Link, useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

const AddJobComp = () => {
  const navigate = useNavigate();


    const [title, setTitle] = useState('');
    const [type, setType] = useState('Full-Time');
    const [id, setId] = useState(1000);
    const [description, setDescription] = useState("");
    const [salary, setSalary] = useState('Under $50K');
    const [location, setLocation] = useState("");
    const [companyName, setCompanyName] = useState("");
    const [companyDescription, setCompanyDescription] = useState("");
    const [contactEmail, setContactEmail] = useState("");
    const [contactPhone, setContactPhone] = useState("");


    const submitForm = (e : any) => {
        e.preventDefault();

        const newJob : Job = {
            title,
            type,
            id: 0,
            description,
            location,
            salary,
            company: {
                name : companyName,
                description  : companyDescription,
                contactEmail,
                contactPhone,
            },
        };

        console.log(newJob);
        jobService.addJob(newJob);

        toast.success('Job created successfull');

        navigate('/jobs');
    }

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

                    {/* Description */}
                    <div className="mb-4">
                        <label 
                            htmlFor="description"
                            className="block text-blue-700 font-bold mb-2">
                            Description
                        </label>
                        <textarea
                            id="descripton"
                            name="description"
                            className="border rounded font-bold w-full py-2 px-3 mb-2"
                            placeholder='Add any job duties, expectations, requirements, etc'
                            rows={4}
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                            />
                    </div>

            {/* Salary */}
            <div className='mb-4'>
              <label
                htmlFor='type'
                className='block text-blue-700 font-bold mb-2'
              >
                Salary
              </label>
              <select
                id='salary'
                name='salary'
                className='border rounded w-full py-2 px-3'
                required
                value={salary}
                onChange={(e) => setSalary(e.target.value)}
              >
                <option value='Under $50K'>Under $50K</option>
                <option value='$50K - 60K'>$50K - $60K</option>
                <option value='$60K - 70K'>$60K - $70K</option>
                <option value='$70K - 80K'>$70K - $80K</option>
                <option value='$80K - 90K'>$80K - $90K</option>
                <option value='$90K - 100K'>$90K - $100K</option>
                <option value='$100K - 125K'>$100K - $125K</option>
                <option value='$125K - 150K'>$125K - $150K</option>
                <option value='$150K - 175K'>$150K - $175K</option>
                <option value='$175K - 200K'>$175K - $200K</option>
                <option value='Over $200K'>Over $200K</option>
              </select>
            </div>

            {/* Location */}
            <div className="mb-4">
                        <label htmlFor='location'
                            className="text-blue-700 font-bold mb-2">
                            Job location
                        </label>
                        <input 
                            type="text"
                            id='location'
                            name='location'
                            className="border rounded font-bold w-full py-2 px-3 mb-2"
                            placeholder='Job location'
                            required
                            value={location}
                            onChange={(e) => setLocation(e.target.value)}
                            />
                    </div>

                    <div className='mb-4'>
              <label
                htmlFor='company'
                className='block text-blue-700 font-bold mb-2'
              >
                Company Name
              </label>
              <input
                type='text'
                id='company'
                name='company'
                className='border rounded w-full py-2 px-3'
                placeholder='Company Name'
                value={companyName}
                onChange={(e) => setCompanyName(e.target.value)}
              />
            </div>

            <div className='mb-4'>
              <label
                htmlFor='company_description'
                className='block text-blue-700 font-bold mb-2'
              >
                Company Description
              </label>
              <textarea
                id='company_description'
                name='company_description'
                className='border rounded w-full py-2 px-3'
                rows= {4}
                placeholder='What does your company do?'
                value={companyDescription}
                onChange={(e) => setCompanyDescription(e.target.value)}
              ></textarea>
            </div>

            {/* Contact Email */}
            <div className='mb-4'>
              <label
                htmlFor='contact_email'
                className='block text-blue-700 font-bold mb-2'
              >
                Contact Email
              </label>
              <input
                type='email'
                id='contact_email'
                name='contact_email'
                className='border rounded w-full py-2 px-3'
                placeholder='Email address for applicants'
                required
                value={contactEmail}
                onChange={(e) => setContactEmail(e.target.value)}
              />

              {/* Contact Phone */}
            </div>
            <div className='mb-4'>
              <label
                htmlFor='contact_phone'
                className='block text-blue-700 font-bold mb-2'
              >
                Contact Phone
              </label>
              <input
                type='tel'
                id='contact_phone'
                name='contact_phone'
                className='border rounded w-full py-2 px-3'
                placeholder='Optional phone for applicants'
                value={contactPhone}
                onChange={(e) => setContactPhone(e.target.value)}
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
                <Link  
                  to='/jobs'  
                  className='text-white text-center bg-orange-500 hover:bg-orange-600 font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block'>
                  Cancel
                </Link>
            </div>
        </div>

    </section>
  )
}

export default AddJobComp