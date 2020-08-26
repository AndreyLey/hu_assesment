import React from 'react';
import { shallow } from 'enzyme';
import Submission from './Submission';

describe('Submission', () => {
  test('matches snapshot', () => {
    const wrapper = shallow(<Submission />);
    expect(wrapper).toMatchSnapshot();
  });
});
